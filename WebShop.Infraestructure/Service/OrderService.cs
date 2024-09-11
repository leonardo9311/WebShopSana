using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;
using WebShop.Core.Interfaces.Service;

namespace WebShop.Infraestructure.Service
{
    public class OrderService : IOrderService
    {
        public Task<OrderDto> CreateOrderAsync(int customerId, IEnumerable<CartItemDto> cartItems)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
