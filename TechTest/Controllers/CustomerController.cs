using Core;
using Core.Adapters.Customers.Interfaces;
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
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customers = await  _customerService.GetAllCustomers();
                return Ok(customers.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest("Not Possible fetch data");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            try 
            {
                var customer = await _customerService.GetCustomerById(id);
                return Ok(customer);
            }catch(Exception ex)
            {
                return BadRequest("User not found or doesn't exist");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            try
            {
                var id = await _customerService.AddCustomer(customer);
                return Created("api/[controller]", id);
            }catch(Exception ex)
            {
                return BadRequest("Unable to create customer");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            try
            {
                await  _customerService.UpdateCustomer(customer);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest("Unable to update customer");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomer(id);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest("Unable to delete customer");
            }
        }
    }
}
