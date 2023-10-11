using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DataBaseModels
{
    internal class OrderDTO
    {
        public int Id { get; set; }
        public int Description { get; set; }
        public int CustomerId { get; set; }
    }
}
