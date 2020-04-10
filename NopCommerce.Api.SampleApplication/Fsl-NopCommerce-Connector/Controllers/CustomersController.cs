using Fsl.NopCommerce.Api.Connector.DTOs;
using Fsl.NopCommerce.Api.Connector.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Controllers
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
        public string Get(int id)
        {
            return "value";
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
        public void Delete(int id)
        {
        }
    }
}
