using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DataBaseModels
{
    public class OrderDTO
    {
        public OrderDTO()
        {
                
        }
        public int Id { get; set; }
        public int Description { get; set; }

        public CustomerDTO? Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
