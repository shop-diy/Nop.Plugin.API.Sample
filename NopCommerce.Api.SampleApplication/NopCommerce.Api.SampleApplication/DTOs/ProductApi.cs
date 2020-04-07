using Newtonsoft.Json;

namespace NopCommerce.Api.Connector.DTOs
{

    public class ProductApi
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}