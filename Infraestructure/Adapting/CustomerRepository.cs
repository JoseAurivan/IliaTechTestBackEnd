using Core;
using Core.Adapters.Customers.Interfaces;
using Infraestructure.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Adapting
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            try 
            {
                var customerDTO = new CustomerDTO(default,customer.Name,customer.Email);
                _context.Add(customerDTO);
                await _context.SaveChangesAsync();
                return customerDTO.Id;
                
            }catch(Exception ex) { throw; }

        }

        public async Task DeleteCustomer(int id)
        {
            try 
            {
                var customerDTO = _context.Customer.FirstOrDefault(x => x.Id == id);
                if(customerDTO is not null) _context.Customer.Remove(customerDTO);
                await _context.SaveChangesAsync();
            } catch (Exception ex) { throw; }

        }

        public async Task<ICollection<Customer>> GetAllCustomers()
        {
            try 
            {
                var customersDTO = await _context.Customer.ToListAsync();
                List<Customer> customers = new List<Customer>();
                foreach (var customer in customersDTO) 
                {
                    customers.Add(customer.ConvertToModel(customer));
                }

                return customers;

            } catch (Exception ex) { throw; }

        }

        public async Task<Customer> GetCustomerById(int id)
        {
            try 
            {
                var customerDTO = await _context.Customer.FirstOrDefaultAsync(x => x.Id == id);
                var customer = customerDTO.ConvertToModel(customerDTO);
                return customer;
            } catch (Exception ex) { throw; }

        }

        public async Task UpdateCustomer(Customer customer)
        {
            try 
            {
                var customerDTO = await _context.Customer.FirstOrDefaultAsync(x => x.Id == customer.CustomerId);
                if(customerDTO is not null)
                {
                    customerDTO.ChangeCustomerData(customer);
                }
            } catch (Exception ex) { throw; }

        }
    }
}
