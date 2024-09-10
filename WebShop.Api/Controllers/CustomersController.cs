using Microsoft.AspNetCore.Mvc;
using WebShop.Core.DTO;
using WebShop.Core.Interfaces.Service;

namespace WebShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // PUT: api/customers
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDto customerDto)
        {
            await _customerService.UpdateCustomerAsync(customerDto);
            return NoContent();
        }
    }
}
