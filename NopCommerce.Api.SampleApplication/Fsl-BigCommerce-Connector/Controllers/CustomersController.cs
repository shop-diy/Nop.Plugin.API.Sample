using Fsl.BigCommerce.Api.Connector.DTOs;
using Fsl.BigCommerce.Api.Connector.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fsl.BigCommerce.Api.Connector.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerRepository _customers;
        public CustomersController(CustomerRepository customerRepository)
        {
            _customers = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allCustomers = await _customers.GetAll();


            return Ok(allCustomers);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customers.GetById(id);

            return Ok(customer);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromQuery]string lastName)
        {
            var result = await _customers.Update(id, new CustomerApi { LastName = lastName });

            return Ok(result);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int _id)
        {
        }
    }
}
