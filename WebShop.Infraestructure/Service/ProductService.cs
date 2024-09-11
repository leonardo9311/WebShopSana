using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;
using WebShop.Core.Entity;
using WebShop.Core.Interfaces.Repository;
using WebShop.Core.Interfaces.Service;
using WebShop.Infraestructure.Repository;

namespace WebShop.Infraestructure.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<bool> CheckProductStockAsync(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;


            var products = _productRepository.GetAll()
            .OrderBy(p => p.ProductID)  
            .Skip((pageNumber - 1) * pageSize)  
            .Take(pageSize)  
            .Select(p => new ProductDto  
            {
                ProductID = p.ProductID,
                ProductCode = p.ProductCode,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity
            }).ToListAsync();



            return await products;
        }
    }
}
