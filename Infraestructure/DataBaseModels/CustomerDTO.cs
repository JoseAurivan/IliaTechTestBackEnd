using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DataBaseModels
{
    public class CustomerDTO
    {
        public CustomerDTO()
        {
                
        }

        public CustomerDTO(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<OrderDTO>? Orders { get; set; }

        public Customer ConvertToModel(CustomerDTO customerDTO) 
        {
            return new Customer(customerDTO.Id,customerDTO.Email,customerDTO.Email);
        }

        public void ChangeCustomerData(Customer customer)
        {
            this.Name = customer.Name;
            this.Email = customer.Email;
        }
    }
}
