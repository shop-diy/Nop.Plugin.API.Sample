using Fsl.NopCommerce.Api.Connector.DTOs.HubSpot;
using Fsl.NopCommerce.Api.Connector.Model.HubSpot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public class HubSpotProductRepository : IHubSpotRepository<HubSpotProduct>
    {
        private readonly IHubSpotService _service;

        public HubSpotProductRepository(IHubSpotService hubSpotService)
        {
            _service = hubSpotService ?? throw new ArgumentNullException(nameof(hubSpotService));
        }

        public async Task AddNew(HubSpotProduct entity)
        {
            var request = new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/products",
                Properties = new Dictionary<string, object>()
            };

            request.Properties[HubSpotProperties.Product.Name] = entity.Name;
            request.Properties[HubSpotProperties.Product.SKU] = entity.SKU;
            request.Properties[HubSpotProperties.Product.Description] = entity.Description;
            request.Properties[HubSpotProperties.Product.BillingFrequency] = entity.BillingFrequency;

            if (entity.UnitCost.HasValue)
            {
                request.Properties[HubSpotProperties.Product.UnitCost] = entity.UnitCost.Value;
            }
            if (entity.UnitPrice.HasValue)
            {
                request.Properties[HubSpotProperties.Product.UnitPrice] = entity.UnitPrice.Value;
            }
            if (entity.UnitDiscount.HasValue)
            {
                request.Properties[HubSpotProperties.Product.UnitDiscount] = entity.UnitDiscount.Value;
            }
            if (entity.DiscountPercentage.HasValue)
            {
                request.Properties[HubSpotProperties.Product.DiscountPercentage] = entity.DiscountPercentage.Value;
            }
            if (!string.IsNullOrWhiteSpace(entity.FolderId))
            {
                request.Properties[HubSpotProperties.Product.FolderId] = entity.FolderId;
            }
            if (entity.Tax.HasValue)
            {
                request.Properties[HubSpotProperties.Product.Tax] = entity.Tax.Value;
            }

            await _service.Post(request);
        }

        public async Task Update(string entityId, HubSpotProduct updatedEntity)
        {
            var request = new HubSpotServiceRequest
            {
                Path = $"crm/v3/objects/products/{entityId}",
                Properties = new Dictionary<string, object>()
            };

            if (updatedEntity.Name != null)
                request.Properties[HubSpotProperties.Product.Name] = updatedEntity.Name;

            if (updatedEntity.SKU != null)
                request.Properties[HubSpotProperties.Product.SKU] = updatedEntity.SKU;

            if (updatedEntity.Description != null)
                request.Properties[HubSpotProperties.Product.Description] = updatedEntity.Description;

            if (updatedEntity.BillingFrequency.HasValue)
                request.Properties[HubSpotProperties.Product.BillingFrequency] = updatedEntity.BillingFrequency.Value;

            if (updatedEntity.UnitCost.HasValue)
                request.Properties[HubSpotProperties.Product.UnitCost] = updatedEntity.UnitCost.Value;

            if (updatedEntity.UnitPrice.HasValue)
                request.Properties[HubSpotProperties.Product.UnitPrice] = updatedEntity.UnitPrice.Value;

            if (updatedEntity.UnitDiscount.HasValue)
                request.Properties[HubSpotProperties.Product.UnitDiscount] = updatedEntity.UnitDiscount.Value;

            if (updatedEntity.DiscountPercentage.HasValue)
                request.Properties[HubSpotProperties.Product.DiscountPercentage] = updatedEntity.DiscountPercentage.Value;

            if (updatedEntity.FolderId != null)
                request.Properties[HubSpotProperties.Product.FolderId] = updatedEntity.FolderId;

            if (updatedEntity.Tax.HasValue)
                request.Properties[HubSpotProperties.Product.Tax] = updatedEntity.Tax.Value;

            await _service.Patch(request);
        }

        public async Task Delete(string entityId)
        {
            var request = new HubSpotServiceRequest
            {
                Path = $"crm/v3/objects/products/{entityId}",
            };

            await _service.Delete(request);
        }

        public async Task<IEnumerable<HubSpotProduct>> GetAll(EntityOptions options = null)
        {
            options ??= new EntityOptions();

            var request = new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/products",
            }
            .IncludeProperties(
                HubSpotProperties.Common.Id,
                HubSpotProperties.Product.Name,
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Common.IsArchived,
                HubSpotProperties.Product.SKU,
                HubSpotProperties.Product.Description,
                HubSpotProperties.Product.UnitPrice,
                HubSpotProperties.Product.UnitCost,
                HubSpotProperties.Product.UnitDiscount,
                HubSpotProperties.Product.DiscountPercentage,
                HubSpotProperties.Product.FolderId,
                HubSpotProperties.Product.BillingFrequency,
                HubSpotProperties.Product.Tax
            )
            .WithAssociations(options.ToAssociationsArray<HubSpotProduct>())
            .LimitedTo(100);

            var response = await _service.Get<HubSpotObjectListDTO>(request);

            if (response.Status != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {response.Status}.");
            }

            return response.Data.Results.Select(dto => FromDto(dto, options));
        }

        public async Task<IEnumerable<HubSpotProduct>> GetBatch(params string[] ids)
        {
            var request = new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/products/batch/read",
            }
            .IncludeProperties(
                HubSpotProperties.Common.Id,
                HubSpotProperties.Product.Name,
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Common.IsArchived,
                HubSpotProperties.Product.SKU,
                HubSpotProperties.Product.Description,
                HubSpotProperties.Product.UnitPrice,
                HubSpotProperties.Product.UnitCost,
                HubSpotProperties.Product.UnitDiscount,
                HubSpotProperties.Product.DiscountPercentage,
                HubSpotProperties.Product.FolderId,
                HubSpotProperties.Product.BillingFrequency,
                HubSpotProperties.Product.Tax
            )
            .WithInputs(ids.Select(id => new { id }).ToArray());

            var response = await _service.Post<HubSpotObjectListDTO>(request);

            if (response.Status != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {response.Status}.");
            }

            return response.Data.Results.Select(dto => FromDto(dto, new EntityOptions { ExcludedAssociations = "Companies,Contacts,LineItems,Deals,Quotes" }));
        }

        public async Task<HubSpotProduct> GetById(string id, EntityOptions options = null)
        {
            options ??= new EntityOptions();

            var request = new HubSpotServiceRequest
            {
                Path = $"crm/v3/objects/products/{id}",
            }
            .IncludeProperties(
                HubSpotProperties.Common.Id,
                HubSpotProperties.Product.Name,
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Common.IsArchived,
                HubSpotProperties.Product.SKU,
                HubSpotProperties.Product.Description,
                HubSpotProperties.Product.UnitPrice,
                HubSpotProperties.Product.UnitCost,
                HubSpotProperties.Product.UnitDiscount,
                HubSpotProperties.Product.DiscountPercentage,
                HubSpotProperties.Product.FolderId,
                HubSpotProperties.Product.BillingFrequency,
                HubSpotProperties.Product.Tax
            )
            .WithAssociations(options.ToAssociationsArray<HubSpotProduct>());

            var response = await _service.Get<HubSpotObjectDTO>(request);

            if (response.Status != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {response.Status}.");
            }

            return FromDto(response.Data, options);
        }

        private HubSpotProduct FromDto(HubSpotObjectDTO dto, EntityOptions options)
        {
            decimal? unitPrice = null;
            if (decimal.TryParse(dto.Properties[HubSpotProperties.Product.UnitPrice], out decimal amt))
                unitPrice = amt;

            decimal? unitCost = null;
            if (decimal.TryParse(dto.Properties[HubSpotProperties.Product.UnitCost], out decimal cost))
                unitCost = cost;

            decimal? unitDiscount = null;
            if (decimal.TryParse(dto.Properties[HubSpotProperties.Product.UnitDiscount], out decimal discount))
                unitDiscount = discount;

            decimal? tax = null;
            if (decimal.TryParse(dto.Properties[HubSpotProperties.Product.Tax], out decimal tx))
                tax = tx;

            float? discountPercentage = null;
            if (float.TryParse(dto.Properties[HubSpotProperties.Product.DiscountPercentage], out float discPercent))
                discountPercentage = discPercent;

            BillingFrequency? billingFrequency = null;
            if (Enum.TryParse<BillingFrequency>(dto.Properties[HubSpotProperties.Product.BillingFrequency], true, out BillingFrequency frequency))
                billingFrequency = frequency;

            var result = new HubSpotProduct
            {
                Id = dto.Id,
                Name = dto.Properties[HubSpotProperties.Product.Name],
                CreatedDate = dto.CreatedAt,
                UpdatedDate = dto.UpdatedAt,
                IsArchived = dto.Archived,
                SKU = dto.Properties[HubSpotProperties.Product.SKU],
                Description = dto.Properties[HubSpotProperties.Product.Description],
                UnitPrice = unitPrice,
                UnitCost = unitCost,
                UnitDiscount = unitDiscount,
                DiscountPercentage = discountPercentage,
                FolderId = dto.Properties[HubSpotProperties.Product.FolderId],
                BillingFrequency = billingFrequency,
                Tax = tax
            }
            .AddAssociatedIds(dto, options);

            return result;
        }
    }
}
