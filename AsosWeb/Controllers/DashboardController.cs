using Core.DTO.Site.Category;
using Core.DTO.Site.Product;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
