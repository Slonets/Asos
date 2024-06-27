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
    }
}
