using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Controllers
{
    [Route("api/line_items")]
    [ApiController]
    public class LineItemsController : ControllerBase
    {
        private readonly HubSpotService _service;

        public LineItemsController(HubSpotService hubSpotService)
        {
            _service = hubSpotService ?? throw new ArgumentNullException(nameof(hubSpotService));
        }

        public async Task<IActionResult> GetAll()
        {
            var request = new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/line_items",
            }
            .IncludeProperties(
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.LineItem.Description,
                HubSpotProperties.LineItem.ProductName,
                HubSpotProperties.LineItem.UnitCost,
                HubSpotProperties.LineItem.UnitPrice,
                HubSpotProperties.LineItem.Quantity,
                HubSpotProperties.LineItem.Amount,
                HubSpotProperties.LineItem.Discount,
                HubSpotProperties.LineItem.DiscountPercentage,
                HubSpotProperties.LineItem.SKU,
                HubSpotProperties.LineItem.Tax,
                HubSpotProperties.LineItem.ProductId,
                HubSpotProperties.LineItem.PositionOnQuote,
                HubSpotProperties.LineItem.Currency,
                HubSpotProperties.ECommerce.DiscountAmount,
                HubSpotProperties.ECommerce.IsSynced,
                HubSpotProperties.ECommerce.SourceAppId,
                HubSpotProperties.ECommerce.SourceStore
           )
            .WithAssociations(
                "companies",
                "deals",
                "contacts",
                "products",
                "tickets",
                "quotes"
            );

            var (statusCode, data) = await _service.Get<HubSpotObjectListDTO>(request);

            if ((int)statusCode < 299 && (int)statusCode > 199)
            {
                return Ok(data);
            }

            return StatusCode((int)statusCode);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var request = new HubSpotServiceRequest
            {
                Path = $"crm/v3/objects/line_items/{id}",
            }
            .IncludeProperties(
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.LineItem.Description,
                HubSpotProperties.LineItem.ProductName,
                HubSpotProperties.LineItem.UnitCost,
                HubSpotProperties.LineItem.UnitPrice,
                HubSpotProperties.LineItem.Quantity,
                HubSpotProperties.LineItem.Amount,
                HubSpotProperties.LineItem.Discount,
                HubSpotProperties.LineItem.DiscountPercentage,
                HubSpotProperties.LineItem.SKU,
                HubSpotProperties.LineItem.Tax,
                HubSpotProperties.LineItem.ProductId,
                HubSpotProperties.LineItem.PositionOnQuote,
                HubSpotProperties.LineItem.Currency,
                HubSpotProperties.ECommerce.DiscountAmount,
                HubSpotProperties.ECommerce.IsSynced,
                HubSpotProperties.ECommerce.SourceAppId,
                HubSpotProperties.ECommerce.SourceStore
            )
            .WithAssociations(
                "companies",
                "deals",
                "contacts",
                "products",
                "tickets",
                "quotes"
            );

            var (statusCode, data) = await _service.Get<HubSpotObjectDTO>(request);

            if ((int)statusCode < 299 && (int)statusCode > 199)
            {
                return Ok(data);
            }

            return StatusCode((int)statusCode);
        }
    }
}