using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            var (Status, Data) = await _service.Get<HubSpotObjectDTO>(request);

            if (Status == System.Net.HttpStatusCode.OK)
            {
                return Ok(Data);
            }

            return StatusCode((int)Status);
        }
    }
}