using Core.Adapters.Customers.Interfaces;
using System;
using System.Collections;
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
            try
            {
                if(customer.Orders?.Count > 0)
                {
                    return await _customerRepository.AddCustomerAndOrder(customer);
                }
                return await _customerRepository.AddCustomer(customer);
                 
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task AddCustomerList(CustomerList customers)
        {
            try
            {
                if(customers.Customers.Count > 0)
                {
                    foreach(var customer in  customers.Customers)
                    {
                        await AddCustomer(customer);
                    }
                }
            }catch(Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteCustomer(int id)
        {
            try
            {
                await _customerRepository.DeleteCustomer(id);
            }
            catch (Exception e) { throw; }

        }

        public async Task<ICollection<Customer>> GetAllCustomers()
        {
            try
            {
                var customers = await _customerRepository.GetAllCustomers();
                return customers;
            }
            catch (Exception e) {throw; }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerById(id);
                return customer;
            }
            catch (Exception e) { throw; }
        }

        public async Task UpdateCustomer(Customer customer)
        {
            try 
            {
                await _customerRepository.UpdateCustomer(customer);
            } catch (Exception e) { throw; }

        }
    }
}
