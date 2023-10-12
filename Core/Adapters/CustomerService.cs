using Core.Adapters.Customers.Interfaces;
using Core.Validations;
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

        public void ValidateEmail(string email) 
        {
            var result = new EmailValidation().Validation(email);
            if (!result) throw new InvalidEmailException();
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            try
            {
                ValidateEmail(customer.Email);
                if(customer.Orders?.Count > 0)
                {
                    return await _customerRepository.AddCustomerAndOrder(customer);
                }
                return await _customerRepository.AddCustomer(customer);
                 
            }
            catch(InvalidEmailException e)
            {
                throw e;
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
                        ValidateEmail(customer.Email);
                        await AddCustomer(customer);
                    }
                }
            }
            catch(InvalidEmailException ex)
            {
                throw ex;
            }
            catch(Exception ex)
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
            catch(DeleteCustomerException ex) { throw; }
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
                ValidateEmail(customer.Email);
                await _customerRepository.UpdateCustomer(customer);
            }
            catch(InvalidEmailException ex)
            {
                throw ex;
            }
            catch(CustomerNullException ex) { throw; }
            catch (Exception e) { throw; }

        }
    }
}
