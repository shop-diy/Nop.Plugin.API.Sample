using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly HubSpotService _service;
        public QuotesController(HubSpotService hubspotService)
        {
            _service = hubspotService ?? throw new ArgumentNullException(nameof(hubspotService));
        }

        public async Task<IActionResult> GetAll()
        {
            var request = new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/quotes",
            }
            .IncludeProperties(
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Quote.ExpirationDate,
                HubSpotProperties.Quote.PublicUrlKey,
                HubSpotProperties.Quote.ApprovalStatus,
                HubSpotProperties.Quote.Amount,
                HubSpotProperties.Quote.ApproverId,
                HubSpotProperties.Quote.Title,
                HubSpotProperties.Common.AssociatedDealCount
            )
            .WithAssociations(
                "deals",
                "line_items",
                "contacts",
                "companies"
            );

            var (Status, Data) = await _service.Get<HubSpotObjectListDTO>(request);

            if (Status == System.Net.HttpStatusCode.OK)
            {
                return Ok(Data);
            }

            return StatusCode((int)Status);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var request = new HubSpotServiceRequest
            {
                Path = $"crm/v3/objects/quotes/{id}",
            }
            .IncludeProperties(
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Quote.ExpirationDate,
                HubSpotProperties.Quote.PublicUrlKey,
                HubSpotProperties.Quote.ApprovalStatus,
                HubSpotProperties.Quote.Amount,
                HubSpotProperties.Quote.ApproverId,
                HubSpotProperties.Quote.Title,
                HubSpotProperties.Common.AssociatedDealCount
            )
            .WithAssociations(
                "deals",
                "line_items",
                "contacts",
                "companies"
            );

            var (Status, Data) = await _service.Get<HubSpotObjectDTO>(request);

            if (Status == System.Net.HttpStatusCode.OK)
            {
                return Ok(Data);
            }

            return StatusCode((int)Status);
        }
    }
}