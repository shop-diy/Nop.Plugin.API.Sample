using Fsl.NopCommerce.Api.Connector.DTOs.HubSpot;
using Fsl.NopCommerce.Api.Connector.Model.HubSpot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public class HubSpotQuoteRepository : IHubSpotReadOnlyRepository<HubSpotQuote>
    {
        private readonly IHubSpotService _service;

        public HubSpotQuoteRepository(IHubSpotService hubSpotService)
        {
            _service = hubSpotService ?? throw new ArgumentNullException(nameof(hubSpotService));
        }

        public async Task<IEnumerable<HubSpotQuote>> GetAll(EntityOptions options = null)
        {
            options ??= new EntityOptions();

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
            .WithAssociations(options.ToAssociationsArray<HubSpotQuote>());

            var response = await _service.Get<HubSpotObjectListDTO>(request);

            if (response.Status != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {response.Status}.");
            }

            return response.Data.Results.Select(dto => FromDto(dto, options));
        }

        public async Task<IEnumerable<HubSpotQuote>> GetBatch(params string[] ids)
        {
            var request = new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/quotes/batch/read",
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
            .WithInputs(ids.Select(id => new { id }).ToArray());

            var response = await _service.Post<HubSpotObjectListDTO>(request);

            if (response.Status != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {response.Status}.");
            }

            return response.Data.Results.Select(dto => FromDto(dto, new EntityOptions { ExcludedAssociations = "Companies,Contacts,LineItems,Deals" }));
        }

        public async Task<HubSpotQuote> GetById(string id, EntityOptions options = null)
        {
            options ??= new EntityOptions();

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
            .WithAssociations(options.ToAssociationsArray<HubSpotQuote>());

            var response = await _service.Get<HubSpotObjectDTO>(request);

            if (response.Status != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {response.Status}.");
            }

            return FromDto(response.Data, options);
        }

        private HubSpotQuote FromDto(HubSpotObjectDTO dto, EntityOptions options)
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
            }
            .AddAssociatedIds(dto, options);

            return result;
        }
    }
}
