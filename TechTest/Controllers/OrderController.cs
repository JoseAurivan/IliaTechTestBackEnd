using Core;
using Core.Adapters.Orders.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetAllOrdersByCustomerId(int id)
        {
            try
            {
                var orders = await _orderService.GetAllOrdersByCustomerId(id);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest("Unable to get orders of this customer");
            }

        }


        [HttpPost]
        public async Task<IActionResult> AddOrders(Order order)
        {
            try
            {
                var id = await _orderService.AddOrder(order);
                return Created("api/[controller]", id);
            }
            catch (Exception ex)
            {
                return BadRequest("Unable to save Order");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            try
            {
                await _orderService.DeleteOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Unable to delete order");
            }
            
        }
    }
}
