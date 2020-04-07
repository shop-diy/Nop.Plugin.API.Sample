using Newtonsoft.Json;

namespace NopCommerce.Api.SampleApplication.DTOs
{

    public class ProductApi
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}