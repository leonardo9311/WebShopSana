using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;

namespace WebShop.Core.Interfaces.Service
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerByIdAsync(int customerId);
        Task UpdateCustomerAsync(CustomerDto customerDto);
    }
}
