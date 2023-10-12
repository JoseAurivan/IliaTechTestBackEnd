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
                return StatusCode(500, "Database could not respond");
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
                return StatusCode(500, "Database could not respond");
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
                return StatusCode(500, "Database could not respond");
            }
        }

        [HttpPost("list")]
        public async Task<IActionResult> AddCustomerList(CustomerList customers)
        {
            try
            {
                await _customerService.AddCustomerList(customers);
                return Created("api/[controller]",null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Database could not respond");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            try
            {
                await  _customerService.UpdateCustomer(customer);
                return Ok();
            }
            catch(CustomerNullException ex)
            {
                return StatusCode(401, "The resource is no longer avalaible");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Database could not respond");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomer(id);
                return Ok();
            }
            catch(DeleteCustomerException ex)
            {
                return StatusCode(401, "The resource is no longer avalaible");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Database could not respond");
            }
        }
    }
}
