using Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public class HubSpotLineItemRepository
    {
        private readonly HubSpotService _service;

        public HubSpotLineItemRepository(HubSpotService hubSpotService)
        {
            _service = hubSpotService ?? throw new ArgumentNullException(nameof(hubSpotService));
        }

        public async Task<IEnumerable<HubSpotLineItem>> GetBatch (params string[] ids)
        {
            var request = new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/line_items/batch/read",
            }
            .IncludeProperties(
                HubSpotProperties.Common.Id,
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Common.IsArchived,
                HubSpotProperties.LineItem.Description,
                HubSpotProperties.LineItem.SKU,
                HubSpotProperties.LineItem.ProductId,
                HubSpotProperties.LineItem.ProductName,
                HubSpotProperties.LineItem.UnitPrice,
                HubSpotProperties.LineItem.Quantity,
                HubSpotProperties.LineItem.Tax,
                HubSpotProperties.LineItem.UnitCost,
                HubSpotProperties.LineItem.Amount,
                HubSpotProperties.LineItem.Discount,
                HubSpotProperties.LineItem.DiscountPercentage,
                HubSpotProperties.LineItem.Currency,
                HubSpotProperties.LineItem.PositionOnQuote
            )
            .WithInputs(ids.Select(id => new { id }).ToArray());

            var (statusCode, data) = await _service.Post<HubSpotObjectListDTO>(request);

            if (statusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {statusCode}.");
            }

            return data.Results.Select(dto => FromDto(dto, excludeQuotes: true, excludeCompanies: true, excludeContacts: true, excludeDeals: true));
        }

        public async Task<HubSpotLineItem> GetById (string id, bool excludeQuotes = false, bool excludeCompanies = false, bool excludeContacts = false, bool excludeDeals = false)
        {
            var associations = new List<string>();

            if (!excludeQuotes)
                associations.Add("quotes");

            if (!excludeCompanies)
                associations.Add("companies");

            if (!excludeContacts)
                associations.Add("contacts");

            if (!excludeDeals)
                associations.Add("deals");

            var request = new HubSpotServiceRequest
            {
                Path = $"crm/v3/objects/line_items/{id}",
            }
            .IncludeProperties(
                HubSpotProperties.Common.Id,
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Common.IsArchived,
                HubSpotProperties.LineItem.Description,
                HubSpotProperties.LineItem.SKU,
                HubSpotProperties.LineItem.ProductId,
                HubSpotProperties.LineItem.ProductName,
                HubSpotProperties.LineItem.UnitPrice,
                HubSpotProperties.LineItem.Quantity,
                HubSpotProperties.LineItem.Tax,
                HubSpotProperties.LineItem.UnitCost,
                HubSpotProperties.LineItem.Amount,
                HubSpotProperties.LineItem.Discount,
                HubSpotProperties.LineItem.DiscountPercentage,
                HubSpotProperties.LineItem.Currency,
                HubSpotProperties.LineItem.PositionOnQuote
            )
            .WithAssociations(associations.ToArray());

            var (statusCode, data) = await _service.Get<HubSpotObjectDTO>(request);

            if (statusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {statusCode}.");
            }

            return FromDto(data, excludeQuotes, excludeCompanies, excludeContacts, excludeDeals);
        }

        private HubSpotLineItem FromDto(HubSpotObjectDTO dto, bool excludeQuotes, bool excludeCompanies, bool excludeContacts, bool excludeDeals)
        {
            int? positionOnQuote = null;
            if (int.TryParse(dto.Properties[HubSpotProperties.LineItem.PositionOnQuote], out int poq))
                positionOnQuote = poq;

            decimal? unitPrice = null;
            if (decimal.TryParse(dto.Properties[HubSpotProperties.LineItem.UnitPrice], out decimal price))
                unitPrice = price;

            int? quantity = null;
            if (int.TryParse(dto.Properties[HubSpotProperties.LineItem.Quantity], out int qty))
                quantity = qty;

            decimal? tax = null;
            if (decimal.TryParse(dto.Properties[HubSpotProperties.LineItem.Tax], out decimal tx))
                tax = tx;

            decimal? unitCost = null;
            if (decimal.TryParse(dto.Properties[HubSpotProperties.LineItem.UnitCost], out decimal cost))
                unitCost = cost;

            decimal? amount = null;
            if (decimal.TryParse(dto.Properties[HubSpotProperties.LineItem.Amount], out decimal amt))
                amount = amt;

            decimal? discount = null;
            if (decimal.TryParse(dto.Properties[HubSpotProperties.LineItem.Discount], out decimal disc))
                discount = disc;

            float? discountPercentage = null;
            if (float.TryParse(dto.Properties[HubSpotProperties.LineItem.DiscountPercentage], out float discPercent))
                discountPercentage = discPercent;

            string name = dto.Properties[HubSpotProperties.LineItem.Description];

            if (string.IsNullOrWhiteSpace(name))
            {
                name = positionOnQuote.HasValue
                    ? $"Item {positionOnQuote.Value + 1}"
                    : "Unnamed Line Item";
            }

            var result = new HubSpotLineItem
            {
                Id = dto.Id,
                Name = name,
                CreatedDate = dto.CreatedAt,
                UpdatedDate = dto.UpdatedAt,
                IsArchived = dto.Archived,
                SKU = dto.Properties[HubSpotProperties.LineItem.SKU],
                ProductId = dto.Properties[HubSpotProperties.LineItem.ProductId],
                ProductName = dto.Properties[HubSpotProperties.LineItem.ProductName],
                UnitPrice = unitPrice,
                Quantity = quantity,
                Tax = tax,
                Amount = amount,
                UnitCost = unitCost,
                Discount = discount,
                DiscountPercentage = discountPercentage,
                Currency = dto.Properties[HubSpotProperties.LineItem.Currency],
                PositionOnQuote = positionOnQuote,
            };

            if (!excludeQuotes && dto.Associations?.Quotes?.Results != null)
            {
                result.AssociatedQuoteIds = dto.Associations.Quotes.Results.Select(link => link.Id);
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
