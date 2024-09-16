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
        Task<OrderDto> CreateOrderAsync(ProcessOrderDto processOrderDto);
        Task<decimal> GetProductPrice(int productId);
    }
}
