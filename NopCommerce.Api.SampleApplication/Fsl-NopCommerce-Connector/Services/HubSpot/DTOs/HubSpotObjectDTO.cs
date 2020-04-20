using Newtonsoft.Json;
using System;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs
{
    public class HubSpotObjectDTO
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime ArchivedAt { get; set; }

        public bool Archived { get; set; }

        [JsonConverter(typeof(HubSpotPropertiesConverter))]
        public dynamic Properties { get; set; }

        public HubSpotAssociationsDTO Associations { get; set; }
    }
}
