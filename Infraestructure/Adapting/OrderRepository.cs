using Core;
using Core.Adapters.Orders.Interfaces;
using Infraestructure.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Adapting
{
    public class OrderRepository : IOrderRepository
    {
        private Context context;

        public OrderRepository(Context context)
        {
            this.context = context;
        }

        public async Task<int> AddOrder(Order order)
        {
            try 
            {
                var orderDTO = new OrderDTO(default,order.Description,order.CustomerId);
                context.Order.Add(orderDTO);
                await context.SaveChangesAsync();
                return orderDTO.Id;

            }catch(Exception) { throw; }

        }

        public async Task DeleteOrder(int id)
        {
            try 
            {
                var orderDTO = await context.Order.FirstOrDefaultAsync(x => x.Id == id);

                if(orderDTO is not null) 
                    context.Remove(orderDTO);

                await context.SaveChangesAsync();

            } catch (Exception) { throw; }

        }

        public async Task<ICollection<Order>> GetAllOrdersByCustomerId(int id)
        {
            try 
            {
                var ordersDTO = await context.Order.Where(x => x.CustomerId == id).ToListAsync();
                List<Order> orders = new List<Order>();
                if(ordersDTO is not null) { 
                    foreach (var orderDTO in ordersDTO)
                    {
                        orders.Add(orderDTO.ConvertToModel(orderDTO));
                    }
                }
                return orders;

            } catch (Exception) { throw; }

        }
    }
}
