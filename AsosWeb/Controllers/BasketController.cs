using Core.DTO.Authentication;
using Core.DTO.Site.Basket;
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

        [Authorize]
        [HttpPost("GetBasketItems")]
        public async Task<IActionResult> GetBasketItems([FromBody] int[] array)
        {
            string number = User.Claims.ToList()[0].Value.ToString();

            int idUser = int.Parse(number);

            var basket = await _basket.GetBasketItems(idUser, array);

            return Ok(basket);
        }

        [HttpPost("GetBasketItemLogout")]
        public async Task<IActionResult> GetBasketItemsLogout([FromBody] int[] array)
        {      

            var basket = await _basket.GetBasketItemsLogout(array);

            return Ok(basket);
        }

        [Authorize]
        [HttpDelete("DeleteBasket/{productId}")]
        public async Task<IActionResult> DeleteProductWithBaset([FromRoute] int productId)
        {
            string number = User.Claims.ToList()[0].Value.ToString();

            int idUser = int.Parse(number);

            var array = await _basket.DeleteProductWithBascet(idUser, productId);

            return Ok(array);
        }


        [HttpPost("PushOrderWhenLogin")]
        public async Task<IActionResult> PushOrderWhenLogin([FromBody] List<OrderItemDto> orderItems)
        {
            string number = User.Claims.ToList()[0].Value.ToString();

            int idUser = int.Parse(number);

            await _basket.PushOrderWhenLogin(idUser, orderItems);

            return Ok();
        }
    }
}
