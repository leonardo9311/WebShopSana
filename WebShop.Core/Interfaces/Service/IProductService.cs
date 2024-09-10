using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;

namespace WebShop.Core.Interfaces.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync(int pageNumber, int pageSize);
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<bool> CheckProductStockAsync(int productId, int quantity);
    }
}
