using Microsoft.AspNetCore.Mvc;
using WebShop.Core.DTO;
using WebShop.Core.Interfaces.Service;

namespace WebShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> ProcessOrder([FromBody] ProcessOrderDto processOrderDto)
        {
            try
            {
                var order = await _orderService.CreateOrderAsync(processOrderDto);
                return Ok(order);
            }
            catch (Exception ex)
            {
                
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
