using Core.DTO.Site.Category;
using Core.DTO.Site.Product;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        public DashboardController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromForm]CreateProductDto model)
        {
            await _productService.Create(model);
            return Ok(model);
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryDto model)
        {
            await _categoryService.Create(model);
            return Ok(model);
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(await _categoryService.GettAll());
        }

        [HttpGet("GetAllPageCategory")]
        public async Task<IActionResult> GetAllCategory([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _categoryService.GetAllPageCategories(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("GetAllBrand")]
        public async Task<IActionResult> GetAllBrand()
        {
            return Ok(await _brandService.GettAll());
        }
        [HttpGet("GetAllSizes")]
        public async Task<IActionResult> GetAllSizes()
        {
            return Ok(await _productService.GettAllSizesAsync());
        }
        [HttpGet("GetAllGenders")]
        public async Task<IActionResult> GetAllGenders()
        {
            return Ok(await _productService.GettAllGendersAsync());
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _productService.GetAllProducts(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet("GetAllProductsForAdmin")]
        public async Task<IActionResult> GetAllProductsForAdmin([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _productService.GetAllProductsForAdmin(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet("GetAllMakeUpProducts")]
        public async Task<IActionResult> GetAllMakeUp([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _productService.GetAllMakeUp(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet("GetAllSkinCareProducts")]
        public async Task<IActionResult> GetAllSkinCare([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _productService.GetAllSkinCare(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet("GetAllHairCareProducts")]
        public async Task<IActionResult> GetAllHairCare([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _productService.GetAllHairCare(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet("GetAllPerfumeProducts")]
        public async Task<IActionResult> GetAllPerfume([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _productService.GetAllPerfume(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet("GetAllManClothing")]
        public async Task<IActionResult> GetAllManClothingAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await _productService.GetAllManClothingAsync(pageNumber, pageSize));
        }
        [HttpGet("GetAllWomanClothing")]
        public async Task<IActionResult> GetAllWomanClothingAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await _productService.GetAllWomanClothingAsync(pageNumber, pageSize));
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return NotFound(); 
        }
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPut("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromForm] UpdateProductDto model)
        {

            try
            {
                model.Id = id;  
                await _productService.Update(model);
                return Ok(new { message = "Product updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the product", error = ex.Message });
            }
        }
        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var productDto = await _productService.GetById(id);
                return Ok(productDto);
            }
            catch (ArgumentException ex)
            {
                // Повертаємо статус 404, якщо продукт не знайдено
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Обробляємо інші можливі помилки
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }
        [HttpGet("GetByIdCard/{id}")]
        public async Task<IActionResult> GetByIdCard(int id)
        {
            try
            {
                var productDto = await _productService.GetByIdCard(id);
                return Ok(productDto);
            }
            catch (ArgumentException ex)
            {
                // Повертаємо статус 404, якщо продукт не знайдено
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Обробляємо інші можливі помилки
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }

        [HttpGet("GetManClothing")]
        public async Task<IActionResult> GetManClothing()
        {
            return Ok(await _productService.GetManClothingAsync());
        }
       
        [HttpGet("GetWomanClothing")]
        public async Task<IActionResult> GetWomanClothing()
        {
            return Ok(await _productService.GetWomanClothingAsync());
        }

        [HttpPost("ArrayFavorite")]
        public async Task<IActionResult> GetArrayFavorite([FromBody] int[] array)
        {
            var products = await _productService.GetArrayFavorite(array);
            return Ok(products);
        }
        [HttpDelete("DeleteImage")]
        public async Task<IActionResult> DeleteImage([FromBody] DeleteImageRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.ImagePath))
            {
                return BadRequest("Image path is required.");
            }

            bool result = await _productService.DeleteImageAsync(request.ImagePath);

            if (!result)
            {
                return NotFound("Image not found or could not be deleted.");
            }

            return Ok("Image deleted successfully.");
        }
        public class DeleteImageRequest
        {
            public string ImagePath { get; set; }
        }

        [HttpPut("AddProductImages/{productId}")]
        public async Task<IActionResult> AddProductImages(int productId, [FromForm] List<IFormFile> images)
        {
            try
            {
                await _productService.AddProductImages(productId, images);
                return Ok(new { message = "Images added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("ReturnNewProductSize")]
        public async Task<IActionResult> ReturnNewProductSize([FromQuery] string nameProduct, [FromQuery] int newSize)
        {
            var result = await _productService.ReturnNewProductSize(nameProduct, newSize);

            return Ok(result);
        }

        [HttpGet("SearchProducts")]
        public async Task<IActionResult> SearchProducts([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Search query is empty.");
            }

            var products = await _productService.SearchProducts(name);

            if (products.Count == 0)
            {
                return NotFound("No products found.");
            }


            return Ok(products);
        }


        [HttpGet("GetAllPerfumeWithoutPagination")]
        public async Task<IActionResult> GetAllPerfumeWithoutPagination()
        {
            var result = await _productService.GetAllPerfumeWithoutPagination();
            return Ok(result);
        }  
        
        [HttpGet("GetAllMakeUpWithoutPagination")]
        public async Task<IActionResult> GetAllMakeUpWithoutPagination()
        {
            var result = await _productService.GetAllMakeUpWithoutPagination();
            return Ok(result);
        }

        [HttpGet("GetAllSkinCareWithoutPagination")]
        public async Task<IActionResult> GetAllSkinCareWithoutPagination()
        {
            var result = await _productService.GetAllSkinCareWithoutPagination();
            return Ok(result);
        }
    }
}
