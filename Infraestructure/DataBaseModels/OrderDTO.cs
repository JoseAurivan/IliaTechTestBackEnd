using Core;
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

        public OrderDTO(int id, string description, int customerId)
        {
            Id = id;
            Description = description;
            CustomerId = customerId;
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public CustomerDTO? Customer { get; set; }
        public int CustomerId { get; set; }

        public Order ConvertToModel(OrderDTO order)
        {
            return new Order(order.Id,order.Description,order.CustomerId);
        }
    }
}
