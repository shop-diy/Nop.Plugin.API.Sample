using Newtonsoft.Json;

namespace Fsl.BigCommerce.Api.Connector.DTOs
{
    public class ProductApi
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }
    }
}