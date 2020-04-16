using Newtonsoft.Json;
using System;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs
{
    public class HubSpotObjectDTO
    {
        public string Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public DateTimeOffset ArchivedAt { get; set; }

        public bool Archived { get; set; }

        [JsonConverter(typeof(HubSpotPropertiesConverter))]
        public dynamic Properties { get; set; }

        public HubSpotAssociationsDTO Associations { get; set; }
    }
}
