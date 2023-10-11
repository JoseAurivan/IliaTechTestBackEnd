using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Order
    {
        public Order()
        {
                
        }
        public Order(int orderId, string description, int customerId)
        {
            OrderId = orderId;
            Description = description;
            CustomerId = customerId;
        }

        public int OrderId { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
    }
}
