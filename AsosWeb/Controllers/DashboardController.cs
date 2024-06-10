using Core.DTO.Site.Product;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AsosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly IProductService _productService;
        public DashboardController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromForm]CreateProductDto model)
        {
            await _productService.Create(model);
            return Ok(model);
        }
    }
}
