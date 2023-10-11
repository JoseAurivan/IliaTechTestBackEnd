using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DataBaseModels
{
    internal class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<OrderDTO>? Orders { get; set; }
    }
}
