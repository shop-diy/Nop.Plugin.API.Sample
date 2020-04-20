using Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public class HubSpotQuoteRepository
    {
        private readonly HubSpotService _service;

        public HubSpotQuoteRepository(HubSpotService hubSpotService)
        {
            _service = hubSpotService ?? throw new ArgumentNullException(nameof(hubSpotService));
        }

        public async Task<IEnumerable<HubSpotQuote>> GetAll(bool excludeLineItems = false, bool excludeCompanies = false, bool excludeContacts = false, bool excludeDeals = false)
        {
            var associations = new List<string>();

            if (!excludeLineItems)
                associations.Add("line_items");

            if (!excludeCompanies)
                associations.Add("companies");

            if (!excludeContacts)
                associations.Add("contacts");

            if (!excludeDeals)
                associations.Add("deals");

            var request = new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/quotes",
            }
            .IncludeProperties(
                HubSpotProperties.Common.Id,
                HubSpotProperties.Quote.Title,
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Common.IsArchived,
                HubSpotProperties.Quote.QuoteNumber,
                HubSpotProperties.Quote.ExpirationDate,
                HubSpotProperties.Quote.Currency,
                HubSpotProperties.Quote.Amount,
                HubSpotProperties.Quote.ApprovalStatus,
                HubSpotProperties.Quote.DiscountDisplayStyle,
                HubSpotProperties.Quote.Terms
            )
            .WithAssociations(associations.ToArray());

            var (statusCode, data) = await _service.Get<HubSpotObjectListDTO>(request);

            if (statusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {statusCode}.");
            }

            return data.Results.Select(dto => FromDto(dto, excludeLineItems, excludeCompanies, excludeContacts, excludeDeals));
        }

        public async Task<HubSpotQuote> GetById(string id, bool excludeLineItems = false, bool excludeCompanies = false, bool excludeContacts = false, bool excludeDeals = false)
        {
            var associations = new List<string>();

            if (!excludeLineItems)
                associations.Add("line_items");

            if (!excludeCompanies)
                associations.Add("companies");

            if (!excludeContacts)
                associations.Add("contacts");

            if (!excludeDeals)
                associations.Add("deals");

            var request = new HubSpotServiceRequest
            {
                Path = $"crm/v3/objects/quotes/{id}",
            }
            .IncludeProperties(
                HubSpotProperties.Common.Id,
                HubSpotProperties.Quote.Title,
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Common.IsArchived,
                HubSpotProperties.Quote.QuoteNumber,
                HubSpotProperties.Quote.ExpirationDate,
                HubSpotProperties.Quote.Currency,
                HubSpotProperties.Quote.Amount,
                HubSpotProperties.Quote.ApprovalStatus,
                HubSpotProperties.Quote.DiscountDisplayStyle,
                HubSpotProperties.Quote.Terms
            )
            .WithAssociations(associations.ToArray());

            var (statusCode, data) = await _service.Get<HubSpotObjectDTO>(request);

            if (statusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {statusCode}.");
            }

            return FromDto(data, excludeLineItems, excludeCompanies, excludeContacts, excludeDeals);
        }

        private HubSpotQuote FromDto(HubSpotObjectDTO dto, bool excludeLineItems, bool excludeCompanies, bool excludeContacts, bool excludeDeals)
        {
            DateTime? expirationDate = null;
            if (DateTime.TryParse(dto.Properties[HubSpotProperties.Quote.ExpirationDate], out DateTime expDate))
                expirationDate = expDate;

            decimal? amount = null;
            if (decimal.TryParse(dto.Properties[HubSpotProperties.Quote.Amount], out decimal amt))
                amount = amt;

            ApprovalStatus? approvalStatus = null;
            if (Enum.TryParse<ApprovalStatus>(dto.Properties[HubSpotProperties.Quote.ApprovalStatus], true, out ApprovalStatus status))
                approvalStatus = status;

            DiscountDisplayStyle? discountDisplayStyle = null;
            if (Enum.TryParse<DiscountDisplayStyle>(dto.Properties[HubSpotProperties.Quote.DiscountDisplayStyle], true, out DiscountDisplayStyle style))
                discountDisplayStyle = style;

            var result = new HubSpotQuote
            {
                Id = dto.Id,
                Name = dto.Properties[HubSpotProperties.Quote.Title],
                CreatedDate = dto.CreatedAt,
                UpdatedDate = dto.UpdatedAt,
                IsArchived = dto.Archived,
                QuoteNumber = dto.Properties[HubSpotProperties.Quote.QuoteNumber],
                ExpirationDate = expirationDate,
                Currency = dto.Properties[HubSpotProperties.Quote.Currency],
                Amount = amount,
                ApprovalStatus = approvalStatus,
                DiscountDisplayStyle = discountDisplayStyle,
                Terms = dto.Properties[HubSpotProperties.Quote.Terms],
            };

            if (!excludeLineItems && dto.Associations?.Line_Items?.Results != null)
            {
                result.AssociatedLineItemIds = dto.Associations.Line_Items.Results.Select(link => link.Id);
            }

            if (!excludeCompanies && dto.Associations?.Companies?.Results != null)
            {
                result.AssociatedCompanyIds = dto.Associations.Companies.Results.Select(link => link.Id);
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
