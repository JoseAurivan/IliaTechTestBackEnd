using Core;
using Core.Adapters.Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Adapting
{
    public class OrderRepository : IOrderRepository
    {
        public Task<int> AddOrder(Order customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Order>> GetAllOrdersByCustomerId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
