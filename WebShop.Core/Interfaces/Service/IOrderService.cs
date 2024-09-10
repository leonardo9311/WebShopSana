using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;

namespace WebShop.Core.Interfaces.Service
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(int customerId, IEnumerable<CartItemDto> cartItems);
        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId);
    }
}
