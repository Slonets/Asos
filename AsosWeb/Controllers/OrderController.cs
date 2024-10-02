using Core.DTO.Site.Basket;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet("OrderInfo")]
        public async Task<IActionResult> OrderInformation([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 2)
        {
            string number = User.Claims.ToList()[0].Value.ToString();

            int idUser = int.Parse(number);

            var orders = await _orderService.GetInfarmationAboutOrder(idUser, pageNumber, pageSize);

            return Ok(orders);
        }

        [Authorize]
        [HttpGet("OrderById")]
        public async Task<IActionResult> OrderById([FromQuery] int id, [FromQuery] int pageNumber= 1, [FromQuery] int pageSize=4)
        {            

            var orders = await _orderService.GetOrderById(id, pageNumber, pageSize);

            return Ok(orders);
        }
    }
}
