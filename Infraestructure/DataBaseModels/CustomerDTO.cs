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

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<OrderDTO>? Orders { get; set; }
    }
}
