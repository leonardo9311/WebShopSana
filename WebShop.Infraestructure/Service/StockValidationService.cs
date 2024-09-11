using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;
using WebShop.Core.Interfaces.Service;

namespace WebShop.Infraestructure.Service
{
    public class StockValidationService : IStockValidationService
    {
        public Task<bool> ValidateStockAsync(IEnumerable<CartItemDto> cartItems)
        {
            throw new NotImplementedException();
        }
    }
}
