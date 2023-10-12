using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CustomerList
    {
        public CustomerList()
        {
            Customers = new List<Customer>();
        }
        public List<Customer> Customers { get; set; } 
    }
}
