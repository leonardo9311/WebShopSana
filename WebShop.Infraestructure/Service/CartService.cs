using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;
using WebShop.Core.Entity;
using WebShop.Core.Interfaces.Repository;
using WebShop.Core.Interfaces.Service;

namespace WebShop.Infraestructure.Service
{
    public class CartService : ICartService
    {
        private readonly IRepository<Product> _productRepository;

        public CartService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task AddToCartAsync(int productId, int quantity)
        {
            Product product = await _productRepository.GetByIdAsync(productId);
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartItemDto>> GetCartItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetCartTotalAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromCartAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCartItemAsync(int productId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
