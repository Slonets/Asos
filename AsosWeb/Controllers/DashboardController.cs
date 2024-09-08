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
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GettAll());
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
        [HttpPut("UpdateCategory/{id}")]
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
    }
}
