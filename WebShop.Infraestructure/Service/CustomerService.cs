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
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerService(IRepository<Customer> customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            Customer customer = new Customer()
            {              
               Email= customerDto.Email,
               FirstName= customerDto.FirstName,
               LastName= customerDto.LastName
            };

           Customer createdCustomer =   await _customerRepository.AddAsync(customer);

            return new CustomerDto()
            {
                CustomerID = createdCustomer.CustomerID,
                Email = createdCustomer.Email,
                FirstName = createdCustomer.FirstName,
                LastName = createdCustomer.LastName,
            };
        }

        public async Task<bool> CustomerExist(int customerId)
        {
            Customer customer = await _customerRepository.GetByIdAsync(customerId);
            return customer != null;
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int customerId)
        {
           Customer customer = await _customerRepository.GetByIdAsync(customerId);
            return new CustomerDto() { 
                CustomerID= customer.CustomerID,
                Email= customer.Email,
                FirstName= customer.FirstName,
                LastName= customer.LastName,
            };
              
        }

        public Task UpdateCustomerAsync(CustomerDto customerDto)
        {
            throw new NotImplementedException();
        }
    }
}
