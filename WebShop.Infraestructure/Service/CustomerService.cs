using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;
using WebShop.Core.Interfaces.Service;

namespace WebShop.Infraestructure.Service
{
    public class CustomerService : ICustomerService
    {
        public Task<CustomerDto> GetCustomerByIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerAsync(CustomerDto customerDto)
        {
            throw new NotImplementedException();
        }
    }
}
