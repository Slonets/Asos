using Core.DTO.Authentication;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsosWeb.Controllers
{
    public class ProductRequest
    {
        public int ProductId { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basket;

        public BasketController (IBasketService basket)
        {
            _basket= basket;
        }

        [Authorize]
        [HttpPost("CreateBasketId")]
        public async Task<IActionResult> CreateBasketId([FromBody] ProductRequest request)
        {
            string number = User.Claims.ToList()[0].Value.ToString();

            int idUser = int.Parse(number);

            await _basket.pushBasketById(idUser, request.ProductId);

            return Ok();
        }

        [Authorize]
        [HttpPost("CreateBasketArray")]
        public async Task<IActionResult> CreateBasketArray([FromBody] int[] array)
        {
            string number = User.Claims.ToList()[0].Value.ToString();

            int idUser = int.Parse(number);

            await _basket.pushBasketArray(idUser, array);

            return Ok();
        }

    }
}
