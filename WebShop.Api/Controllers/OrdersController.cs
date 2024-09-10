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
            var order = await _orderService.CreateOrderAsync(processOrderDto.CustomerID, processOrderDto.CartItems);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderID }, order);
        }

        // GET: api/orders/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // GET: api/orders/customer/{customerId}
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomer(int customerId)
        {
            var orders = await _orderService.GetOrdersByCustomerIdAsync(customerId);
            return Ok(orders);
        }
    }
}
