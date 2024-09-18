using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;
using WebShop.Core.Entity;

namespace WebShop.Core.Interfaces.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync(int pageNumber, int pageSize);
        Task<List<Product>> GetProductsByIdsAsync(List<int> productIds);
        Task UpdateStockAsync(List<OrderDetail> orderDetails);
        Task<bool> CheckProductStockAsync(int productId, int quantity);
    }
}
