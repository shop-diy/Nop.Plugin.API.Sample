using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fsl.BigCommerce.Api.Connector.DTOs
{
    public class ProductsRootObject
    {
        [JsonProperty("products")]
        public List<ProductApi> Products { get; set; }
    }
}