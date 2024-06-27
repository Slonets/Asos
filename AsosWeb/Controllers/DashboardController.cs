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
        public DashboardController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromForm]CreateProductDto model)
        {
            await _productService.Create(model);
            return Ok(model);
        }
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _categoryService.GettAll());
        }
    }
}
