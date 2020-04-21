using Fsl.NopCommerce.Api.Connector.DTOs.HubSpot;
using Fsl.NopCommerce.Api.Connector.Model.HubSpot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public sealed class HubSpotContactRepository : IHubSpotReadOnlyRepository<HubSpotContact>
    {
        private readonly IHubSpotService _service;

        public HubSpotContactRepository(IHubSpotService hubSpotService)
        {
            _service = hubSpotService ?? throw new ArgumentNullException(nameof(hubSpotService));
        }

        public async Task<IEnumerable<HubSpotContact>> GetAll(EntityOptions options = null)
        {
            options ??= new EntityOptions();

            var request = new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/contacts",
            }
            .IncludeProperties(
                HubSpotProperties.Common.Id,
                HubSpotProperties.Quote.Title,
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Common.IsArchived,
                HubSpotProperties.Contact.FirstName,
                HubSpotProperties.Contact.LastName,
                HubSpotProperties.Contact.Email,
                HubSpotProperties.Contact.WorkEmail,
                HubSpotProperties.Contact.JobTitle,
                HubSpotProperties.Contact.MobileNumber,
                HubSpotProperties.Contact.PhoneNumber
            )
            .WithAssociations(options.ToAssociationsArray<HubSpotContact>());

            var response = await _service.Get<HubSpotObjectListDTO>(request);

            if (response.Status != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {response.Status}.");
            }

            return response.Data.Results.Select(dto => FromDto(dto, options));
        }

        public async Task<IEnumerable<HubSpotContact>> GetBatch(params string[] ids)
        {
            var request = new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/contacts/batch/read",
            }
            .IncludeProperties(
                HubSpotProperties.Common.Id,
                HubSpotProperties.Quote.Title,
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Common.IsArchived,
                HubSpotProperties.Contact.FirstName,
                HubSpotProperties.Contact.LastName,
                HubSpotProperties.Contact.Email,
                HubSpotProperties.Contact.WorkEmail,
                HubSpotProperties.Contact.JobTitle,
                HubSpotProperties.Contact.MobileNumber,
                HubSpotProperties.Contact.PhoneNumber
            )
            .WithInputs(ids.Select(id => new { id }).ToArray());

            var response = await _service.Post<HubSpotObjectListDTO>(request);

            if (response.Status != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {response.Status}.");
            }

            return response.Data.Results.Select(dto => FromDto(dto, new EntityOptions { ExcludedAssociations = "Quotes,Companies,LineItems,Deals" }));
        }

        public async Task<HubSpotContact> GetById(string id, EntityOptions options = null)
        {
            options ??= new EntityOptions();

            var request = new HubSpotServiceRequest
            {
                Path = $"crm/v3/objects/contacts/{id}",
            }
            .IncludeProperties(
                HubSpotProperties.Common.Id,
                HubSpotProperties.Quote.Title,
                HubSpotProperties.Common.CreatedDate,
                HubSpotProperties.Common.LastModifiedDate,
                HubSpotProperties.Common.IsArchived,
                HubSpotProperties.Contact.FirstName,
                HubSpotProperties.Contact.LastName,
                HubSpotProperties.Contact.Email,
                HubSpotProperties.Contact.WorkEmail,
                HubSpotProperties.Contact.JobTitle,
                HubSpotProperties.Contact.MobileNumber,
                HubSpotProperties.Contact.PhoneNumber
            )
            .WithAssociations(options.ToAssociationsArray<HubSpotContact>());

            var response = await _service.Get<HubSpotObjectDTO>(request);

            if (response.Status != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {response.Status}.");
            }

            return FromDto(response.Data, options);
        }

        private HubSpotContact FromDto(HubSpotObjectDTO dto, EntityOptions options)
        {
            var firstName = dto.Properties[HubSpotProperties.Contact.FirstName];
            var lastName = dto.Properties[HubSpotProperties.Contact.LastName];
            var name = $"Contact {dto.Id}";

            if (!string.IsNullOrEmpty(firstName))
            {
                if (!string.IsNullOrEmpty(lastName))
                {
                    name = $"{lastName}, {firstName}";
                }
                else
                {
                    name = firstName;
                }
            } else if (!string.IsNullOrEmpty(lastName))
            {
                name = lastName;
            }

            var result = new HubSpotContact
            {
                Id = dto.Id,
                Name = name,
                CreatedDate = dto.CreatedAt,
                UpdatedDate = dto.UpdatedAt,
                IsArchived = dto.Archived,
                FirstName = dto.Properties[HubSpotProperties.Contact.FirstName],
                LastName = dto.Properties[HubSpotProperties.Contact.LastName],
                Email = dto.Properties[HubSpotProperties.Contact.Email],
                WorkEmail = dto.Properties[HubSpotProperties.Contact.WorkEmail],
                JobTitle = dto.Properties[HubSpotProperties.Contact.JobTitle],
                MobileNumber = dto.Properties[HubSpotProperties.Contact.MobileNumber],
                PhoneNumber = dto.Properties[HubSpotProperties.Contact.PhoneNumber],
            }
            .AddAssociatedIds(dto, options);

            return result;
        }
    }
}