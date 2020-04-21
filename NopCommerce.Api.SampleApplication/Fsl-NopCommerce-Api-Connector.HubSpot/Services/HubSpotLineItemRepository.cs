using Fsl.NopCommerce.Api.Connector.DTOs.HubSpot;
using Fsl.NopCommerce.Api.Connector.Model.HubSpot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public class HubSpotLineItemRepository : IHubSpotReadOnlyRepository<HubSpotLineItem>
    {
        private readonly IHubSpotService _service;

        public HubSpotLineItemRepository(IHubSpotService hubSpotService)
        {
            _service = hubSpotService ?? throw new ArgumentNullException(nameof(hubSpotService));
        }

        public Task<IEnumerable<HubSpotLineItem>> GetAll(EntityOptions options = null)
        {
            throw new NotImplementedException("Cannot get all line items.");
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

            var response = await _service.Post<HubSpotObjectListDTO>(request);

            if (response.Status != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {response.Status}.");
            }

            return response.Data.Results.Select(dto => FromDto(dto, new EntityOptions { ExcludedAssociations = "Quotes,Companies,Contacts,Deals" }));
        }

        public async Task<HubSpotLineItem> GetById (string id, EntityOptions options = null)
        {
            options ??= new EntityOptions();

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
            .WithAssociations(options.ToAssociationsArray<HubSpotContact>());

            var response = await _service.Get<HubSpotObjectDTO>(request);

            if (response.Status != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {response.Status}.");
            }

            return FromDto(response.Data, options);
        }

        private HubSpotLineItem FromDto(HubSpotObjectDTO dto, EntityOptions options)
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
            }
            .AddAssociatedIds(dto, options);

            return result;
        }
    }
}
