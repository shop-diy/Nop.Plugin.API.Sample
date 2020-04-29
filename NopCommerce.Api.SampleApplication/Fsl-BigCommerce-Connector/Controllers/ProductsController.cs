using Fsl.BigCommerce.Api.Connector.DTOs;
using Fsl.BigCommerce.Api.Connector.Repositories;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using Fsl.NopCommerce.Api.Connector.Model.HubSpot;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace Fsl.BigCommerce.Api.Connector.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _products;
        private readonly HubSpotContext _hubSpot;

        public ProductsController(ProductRepository productRepository, HubSpotContext hubSpotContext)
        {
            _hubSpot = hubSpotContext ?? throw new ArgumentNullException(nameof(hubSpotContext));
            _products = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _products.GetAll();

            await _products.SyncBigCommerceProductToHubspot(products);


            return Ok();
        }

        [HttpGet("hs")]
        public async Task<IActionResult> GetHubSpotProducts()
        {
            try
            {
                var newProduct = new HubSpotProduct
                {
                    SKU = "TEST04",
                    Name = "Test Product 4",
                    UnitPrice = 555.55m,
                    Description = "This is to test billing frequency field.",
                    BillingFrequency = BillingFrequency.SemiAnnually
                };

                await _hubSpot.Products.AddNew(newProduct);

                return Ok();
            }
            catch (HttpRequestException exHttp)
            {
                return StatusCode(402, exHttp.Message);
            }
        }

        [HttpGet("hs/{id}")]
        public async Task<IActionResult> UpdateHubSpotProduct(string id)
        {
            var updatedProduct = new HubSpotProduct
            {
                Name = "Cool New Product",
                Tax = 16.77m
            };

            try
            {
                await _hubSpot.Products.Update(id, updatedProduct);

                return Ok();
            }
            catch (HttpRequestException exHttp)
            {
                return StatusCode(402, exHttp.Message);
            }
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
