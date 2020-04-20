using Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public class HubSpotCompanyRepository
    {
        private readonly HubSpotService _service;

        public HubSpotCompanyRepository(HubSpotService hubSpotService)
        {
            _service = hubSpotService ?? throw new ArgumentNullException(nameof(hubSpotService));
        }

        public async Task<IEnumerable<HubSpotCompany>> GetBatch(params string[] ids)
        {
            var request = new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/companies/batch/read",
            }
            .IncludeProperties(
                HubSpotProperties.Common.Id,
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Common.IsArchived,
                HubSpotProperties.Company.Name,
                HubSpotProperties.Company.Description,
                HubSpotProperties.Company.Type,
                HubSpotProperties.Company.OwnerName,
                HubSpotProperties.Company.OwnerEmail,
                HubSpotProperties.Company.Address1,
                HubSpotProperties.Company.Address2,
                HubSpotProperties.Company.City,
                HubSpotProperties.Company.State,
                HubSpotProperties.Company.Zip,
                HubSpotProperties.Company.Country,
                HubSpotProperties.Company.BillingAddress1,
                //HubSpotProperties.Company.BillingAddress2,
                HubSpotProperties.Company.BillingCity,
                HubSpotProperties.Company.BillingState,
                HubSpotProperties.Company.BillingZip,
                HubSpotProperties.Company.BillingCountry,
                HubSpotProperties.Company.Phone,
                HubSpotProperties.Company.Website,
                HubSpotProperties.Company.Domain,
                HubSpotProperties.Company.EmployeeCount,
                HubSpotProperties.Company.Industry,
                HubSpotProperties.Company.AnnualRevenue,
                HubSpotProperties.Company.LeadStatus,
                HubSpotProperties.Company.CloseDate
            )
            .WithInputs(ids.Select(id => new { id }).ToArray());

            var (statusCode, data) = await _service.Post<HubSpotObjectListDTO>(request);

            if (statusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {statusCode}.");
            }

            return data.Results.Select(dto => FromDto(dto, excludeQuotes: true, excludeLineItems: true, excludeContacts: true, excludeDeals: true));
        }

        public async Task<IEnumerable<HubSpotCompany>> GetAll (bool excludeQuotes = false, bool excludeLineItems = false, bool excludeContacts = false, bool excludeDeals = false)
        {
            var associations = new List<string>();

            if (!excludeQuotes)
                associations.Add("quotes");

            if (!excludeLineItems)
                associations.Add("line_items");

            if (!excludeContacts)
                associations.Add("contacts");

            if (!excludeDeals)
                associations.Add("deals");

            var request = new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/companies",
            }
            .IncludeProperties(
                HubSpotProperties.Common.Id,
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Common.IsArchived,
                HubSpotProperties.Company.Name,
                HubSpotProperties.Company.Description,
                HubSpotProperties.Company.Type,
                HubSpotProperties.Company.OwnerName,
                HubSpotProperties.Company.OwnerEmail,
                HubSpotProperties.Company.Address1,
                HubSpotProperties.Company.Address2,
                HubSpotProperties.Company.City,
                HubSpotProperties.Company.State,
                HubSpotProperties.Company.Zip,
                HubSpotProperties.Company.Country,
                HubSpotProperties.Company.BillingAddress1,
                //HubSpotProperties.Company.BillingAddress2,
                HubSpotProperties.Company.BillingCity,
                HubSpotProperties.Company.BillingState,
                HubSpotProperties.Company.BillingZip,
                HubSpotProperties.Company.BillingCountry,
                HubSpotProperties.Company.Phone,
                HubSpotProperties.Company.Website,
                HubSpotProperties.Company.Domain,
                HubSpotProperties.Company.EmployeeCount,
                HubSpotProperties.Company.Industry,
                HubSpotProperties.Company.AnnualRevenue,
                HubSpotProperties.Company.LeadStatus,
                HubSpotProperties.Company.CloseDate
            )
            .WithAssociations(associations.ToArray());

            var (statusCode, data) = await _service.Get<HubSpotObjectListDTO>(request);

            if (statusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {statusCode}.");
            }

            return data.Results.Select(dto => FromDto(dto, excludeQuotes, excludeLineItems, excludeContacts, excludeDeals));
        }

        public async Task<HubSpotCompany> GetById (string id, bool excludeQuotes = false, bool excludeLineItems = false, bool excludeContacts = false, bool excludeDeals = false)
        {
            var associations = new List<string>();

            if (!excludeQuotes)
                associations.Add("quotes");

            if (!excludeLineItems)
                associations.Add("line_items");

            if (!excludeContacts)
                associations.Add("contacts");

            if (!excludeDeals)
                associations.Add("deals");

            var request = new HubSpotServiceRequest
            {
                Path = $"crm/v3/objects/companies/{id}",
            }
            .IncludeProperties(
                HubSpotProperties.Common.Id,
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Common.IsArchived,
                HubSpotProperties.Company.Name,
                HubSpotProperties.Company.Description,
                HubSpotProperties.Company.Type,
                HubSpotProperties.Company.OwnerName,
                HubSpotProperties.Company.OwnerEmail,
                HubSpotProperties.Company.Address1,
                HubSpotProperties.Company.Address2,
                HubSpotProperties.Company.City,
                HubSpotProperties.Company.State,
                HubSpotProperties.Company.Zip,
                HubSpotProperties.Company.Country,
                HubSpotProperties.Company.BillingAddress1,
                //HubSpotProperties.Company.BillingAddress2,
                HubSpotProperties.Company.BillingCity,
                HubSpotProperties.Company.BillingState,
                HubSpotProperties.Company.BillingZip,
                HubSpotProperties.Company.BillingCountry,
                HubSpotProperties.Company.Phone,
                HubSpotProperties.Company.Website,
                HubSpotProperties.Company.Domain,
                HubSpotProperties.Company.EmployeeCount,
                HubSpotProperties.Company.Industry,
                HubSpotProperties.Company.AnnualRevenue,
                HubSpotProperties.Company.LeadStatus,
                HubSpotProperties.Company.CloseDate
            )
            .WithAssociations(associations.ToArray());

            var (statusCode, data) = await _service.Get<HubSpotObjectDTO>(request);

            if (statusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {statusCode}.");
            }

            return FromDto(data, excludeQuotes, excludeLineItems, excludeContacts, excludeDeals);
        }

        private HubSpotCompany FromDto(HubSpotObjectDTO dto, bool excludeQuotes, bool excludeLineItems, bool excludeContacts, bool excludeDeals)
        {
            CompanyType? companyType = null;
            if (Enum.TryParse<CompanyType>(dto.Properties[HubSpotProperties.Company.Type], true, out CompanyType type))
                companyType = type;

            int? employeeCount = null;
            if (int.TryParse(dto.Properties[HubSpotProperties.Company.EmployeeCount], out int empCount))
                employeeCount = empCount;

            decimal? annualRevenue = null;
            if (decimal.TryParse(dto.Properties[HubSpotProperties.Company.AnnualRevenue], out decimal revenue))
                annualRevenue = revenue;

            DateTime? closeDate = null;
            if (DateTime.TryParse(dto.Properties[HubSpotProperties.Company.CloseDate], out DateTime closed))
                closeDate = closed;

            var result = new HubSpotCompany
            {
                Id = dto.Id,
                Name = dto.Properties[HubSpotProperties.Company.Name],
                CreatedDate = dto.CreatedAt,
                UpdatedDate = dto.UpdatedAt,
                IsArchived = dto.Archived,
                Description = dto.Properties[HubSpotProperties.Company.Description],
                Type = companyType,
                OwnerName = dto.Properties[HubSpotProperties.Company.OwnerName],
                OwnerEmail = dto.Properties[HubSpotProperties.Company.OwnerEmail],
                Address1 = dto.Properties[HubSpotProperties.Company.Address1],
                Address2 = dto.Properties[HubSpotProperties.Company.Address2],
                City = dto.Properties[HubSpotProperties.Company.City],
                State = dto.Properties[HubSpotProperties.Company.State],
                Zip = dto.Properties[HubSpotProperties.Company.Zip],
                Country = dto.Properties[HubSpotProperties.Company.Country],
                BillingAddress1 = dto.Properties[HubSpotProperties.Company.BillingAddress1],
                //BillingAddress2 = dto.Properties[HubSpotProperties.Company.BillingAddress2],
                BillingCity = dto.Properties[HubSpotProperties.Company.BillingCity],
                BillingState = dto.Properties[HubSpotProperties.Company.BillingState],
                BillingZip = dto.Properties[HubSpotProperties.Company.BillingZip],
                BillingCountry = dto.Properties[HubSpotProperties.Company.BillingCountry],
                Phone = dto.Properties[HubSpotProperties.Company.Phone],
                WebSite = dto.Properties[HubSpotProperties.Company.Website],
                Domain = dto.Properties[HubSpotProperties.Company.Domain],
                EmployeeCount = employeeCount,
                Industry = dto.Properties[HubSpotProperties.Company.Industry],
                AnnualRevenue = annualRevenue,
                LeadStatus = dto.Properties[HubSpotProperties.Company.LeadStatus],
                CloseDate = closeDate,
            };

            if (!excludeQuotes && dto.Associations?.Quotes?.Results != null)
            {
                result.AssociatedQuoteIds = dto.Associations.Quotes.Results.Select(link => link.Id);
            }
            if (!excludeLineItems && dto.Associations?.Line_Items?.Results != null)
            {
                result.AssociatedLineItemIds = dto.Associations.Line_Items.Results.Select(link => link.Id);
            }

            if (!excludeContacts && dto.Associations?.Contacts?.Results != null)
            {
                result.AssociatedContactIds = dto.Associations.Contacts.Results.Select(link => link.Id);
            }

            if (!excludeDeals && dto.Associations?.Deals?.Results != null)
            {
                result.AssociatedDealIds = dto.Associations.Deals.Results.Select(link => link.Id);
            }

            return result;
        }
    }
}
