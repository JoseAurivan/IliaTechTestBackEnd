using Core.Adapters.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Adapters
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            await _customerRepository.AddCustomer(customer);
        }

        public Task DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Customer>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
