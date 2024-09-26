using Microsoft.AspNetCore.Mvc;
using OrderAccumulator.Models;
using OrderAccumulator.Services;

namespace OrderAccumulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }

        [HttpPost]
        public IActionResult PostOrder([FromBody] Order order)
        {
            var response = _orderService.RegistrarOrdem(order);
            return Ok(response);
        }
    }
}
