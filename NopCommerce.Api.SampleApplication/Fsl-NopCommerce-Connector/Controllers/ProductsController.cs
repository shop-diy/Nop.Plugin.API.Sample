using Fsl.NopCommerce.Api.Connector.DTOs;
using Fsl.NopCommerce.Api.Connector.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _products;
        public ProductsController(ProductRepository productRepository)
        {
            _products = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var all = await _products.GetAll();

            await _products.SyncProducts(all);


            return Ok(all);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int _id)
        {
            throw new NotImplementedException();
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string _value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public Task<IActionResult> Put([FromRoute]int _id, [FromQuery]string _name)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int _id)
        {
            throw new NotImplementedException();
        }
    }
}
