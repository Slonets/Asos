using Core.DTO.Site.Basket;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace AsosWeb.Controllers
{

    public class ChangeStatusRequest
    {
        public int NewStatus { get; set; }
        public int Id { get; set; }
    }

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

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();

            return Ok(orders);
        }

        [HttpGet("ResiveOrderById/{id}")]
        public async Task<IActionResult> ResiveOrderById(int id)
        {

            var orders = await _orderService.ResiveOrderById(id);

            return Ok(orders);
        }

        [HttpGet("GetAllStatus")]
        public async Task<IActionResult> GetAllStatus()
        {
            return Ok(await _orderService.GetAllStatus());
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusRequest request)
        {

            await _orderService.ChangeStatus(request.NewStatus, request.Id);

            return Ok();
        }
    }
}
