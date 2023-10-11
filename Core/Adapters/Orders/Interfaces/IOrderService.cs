using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Adapters.Orders.Interfaces
{
    public interface IOrderService
    {
        Task<ICollection<Order>> GetAllOrdersByCustomerId(int id);
        Task<int> AddOrder(Order order);
        Task DeleteOrder(int id);

    }
}
