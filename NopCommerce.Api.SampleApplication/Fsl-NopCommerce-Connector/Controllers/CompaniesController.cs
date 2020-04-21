using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly HubSpotContext _hubSpot;

        public CompaniesController(HubSpotContext hubSpotContext)
        {
            _hubSpot = hubSpotContext ?? throw new ArgumentNullException(nameof(hubSpotContext));
        }

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allCompanies = await _hubSpot.Companies.GetAll();

                return Ok(allCompanies);
            }
            catch (HttpRequestException exHttp)
            {
                return StatusCode(402, exHttp.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var company = await _hubSpot.Companies.GetById(id);

                return NotFound();
            }
            catch (HttpRequestException exHttp)
            {
                return StatusCode(402, exHttp.Message);
            }
        }
    }
}