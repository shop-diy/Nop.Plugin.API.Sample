using Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public sealed class HubSpotContactRepository
    {
        private readonly HubSpotService _service;

        public HubSpotContactRepository(HubSpotService hubSpotService)
        {
            _service = hubSpotService ?? throw new ArgumentNullException(nameof(hubSpotService));
        }

        public async Task<IEnumerable<HubSpotContact>> GetAll(bool excludeCompanies = false)
        {
            var associations = new List<string>();

            if (!excludeCompanies)
                associations.Add("companies");

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
            .WithAssociations(associations.ToArray());

            var (statusCode, data) = await _service.Get<HubSpotObjectListDTO>(request);

            if (statusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {statusCode}.");
            }

            return data.Results.Select(dto => FromDto(dto, excludeCompanies));
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

            var (statusCode, data) = await _service.Post<HubSpotObjectListDTO>(request);

            if (statusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {statusCode}.");
            }

            return data.Results.Select(dto => FromDto(dto, excludeCompanies: true));
        }

        public async Task<HubSpotContact> GetById(string id, bool excludeCompanies = false)
        {
            var associations = new List<string>();

            if (!excludeCompanies)
                associations.Add("companies");

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
            .WithAssociations(associations.ToArray());

            var (statusCode, data) = await _service.Get<HubSpotObjectDTO>(request);

            if (statusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Net.Http.HttpRequestException($"Request responded with HTTP status {statusCode}.");
            }

            return FromDto(data, excludeCompanies);
        }

        private HubSpotContact FromDto(HubSpotObjectDTO dto, bool excludeCompanies)
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
            };

            if (!excludeCompanies && dto.Associations?.Companies?.Results != null)
            {
                result.AssociatedCompanyIds = dto.Associations.Companies.Results.Select(link => link.Id);
            }

            return result;
        }
    }
}