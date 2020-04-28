using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fsl.BigCommerce.Api.Connector.Controllers
{
    [Route("api/line_items")]
    [ApiController]
    public class LineItemsController : ControllerBase
    {
        private readonly HubSpotContext _hubSpot;

        public LineItemsController(HubSpotContext hubSpotContext)
        {
            _hubSpot = hubSpotContext ?? throw new ArgumentNullException(nameof(hubSpotContext));
        }

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allLineItems = await _hubSpot.LineItems.GetAll();

                return NotFound();
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
                var lineItem = await _hubSpot.LineItems.GetById(id);

                return NotFound();
            }
            catch (HttpRequestException exHttp)
            {
                return StatusCode(402, exHttp.Message);
            }
        }
    }
}