using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;

namespace WebShop.Core.Interfaces.Service
{
    public interface ICartService
    {
        Task AddToCartAsync(int productId, int quantity);
        Task<IEnumerable<CartItemDto>> GetCartItemsAsync();
        Task UpdateCartItemAsync(int productId, int quantity);
        Task RemoveFromCartAsync(int productId);
        Task<decimal> GetCartTotalAsync();
    }
}
