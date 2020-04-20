using Fsl.NopCommerce.Api.Connector.Mapping;
using Fsl.NopCommerce.Api.Connector.Services.Acumatica.DTOs;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly HubSpotService _service;

        public CompaniesController(HubSpotService hubSpotService)
        {
            _service = hubSpotService ?? throw new ArgumentNullException(nameof(hubSpotService));
        }

        public async Task<IActionResult> GetAll()
        {
            var request = new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/companies",
            }
            .IncludeProperties(
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Company.Name,
                HubSpotProperties.Company.Website,
                HubSpotProperties.Company.Type,
                HubSpotProperties.Company.Description,
                HubSpotProperties.Company.EmployeeCount,
                HubSpotProperties.Company.HubSpotScore,
                HubSpotProperties.Company.Industry,
                HubSpotProperties.Company.IsPublic,
                HubSpotProperties.Company.LastSalesActivityDate,
                HubSpotProperties.Company.LifecycleStage,
                HubSpotProperties.Company.OwnerName,
                HubSpotProperties.Company.TotalRevenue
           )
            .WithAssociations(
                "deals",
                "line_items",
                "contacts",
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
                Path = $"crm/v3/objects/companies/{id}",
            }
            .IncludeProperties(
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Company.Name,
                HubSpotProperties.Company.Website,
                HubSpotProperties.Company.Type,
                HubSpotProperties.Company.Description,
                HubSpotProperties.Company.EmployeeCount,
                HubSpotProperties.Company.HubSpotScore,
                HubSpotProperties.Company.Industry,
                HubSpotProperties.Company.IsPublic,
                HubSpotProperties.Company.LastSalesActivityDate,
                HubSpotProperties.Company.LifecycleStage,
                HubSpotProperties.Company.OwnerName,
                HubSpotProperties.Company.TotalRevenue
            )
            .WithAssociations(
                "deals",
                "line_items",
                "contacts",
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