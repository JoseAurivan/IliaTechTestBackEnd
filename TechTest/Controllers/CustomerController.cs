using Core;
using Core.Adapters.Customer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            return Created("api/[controller]", customer);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            return Ok();
        }
    }
}
