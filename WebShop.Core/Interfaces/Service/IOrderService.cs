using WebShop.Core.DTO;

namespace WebShop.Core.Interfaces.Service
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(ProcessOrderDto processOrderDto);     
    }
}
