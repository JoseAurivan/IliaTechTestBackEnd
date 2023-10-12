using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Adapters.Customers.Interfaces
{
    public interface ICustomerService
    {
        Task<ICollection<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<int> AddCustomer(Customer customer);
        Task AddCustomerList(CustomerList customer);
        Task DeleteCustomer(int id);
        Task UpdateCustomer(Customer customer);

    }
}
