using System.Collections.Generic;
using Newtonsoft.Json;

namespace NopCommerce.Api.Connector.DTOs
{
    public class ProductsRootObject
    {
        [JsonProperty("products")]
        public List<ProductApi> Products { get; set; }
    }
}