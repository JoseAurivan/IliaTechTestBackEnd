using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("customer/{id}")]
        public IActionResult GetAllOrdersByCustomerId(int id)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id) {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddOrders(Order order) 
        {
            return Created("api/[controller]",order);
        }

        [HttpPut]
        public IActionResult UpdateOrders(Order order)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrders(int id)
        {
            return Ok();
        }
    }
}
