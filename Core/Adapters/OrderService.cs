using Core.Adapters.Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Adapters
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<int> AddOrder(Order order)
        {
            try 
            {
                var id = _orderRepository.AddOrder(order);
                return id;
            }catch (Exception ex) { throw; }

        }

        public async Task DeleteOrder(int id)
        {
            try 
            {
                await _orderRepository.DeleteOrder(id);
            } catch (Exception ex) { throw; }

        }

        public async Task<ICollection<Order>> GetAllOrdersByCustomerId(int id)
        {
            try 
            {
                var orders =  await _orderRepository.GetAllOrdersByCustomerId(id);
                return orders;
            } catch (Exception ex) { throw; }

        }
    }
}
