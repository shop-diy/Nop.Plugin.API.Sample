using System.Collections.Generic;
using Newtonsoft.Json;

namespace NopCommerce.Api.SampleApplication.DTOs
{
    public class ProductsRootObject
    {
        [JsonProperty("products")]
        public List<ProductApi> Products { get; set; }
    }
}