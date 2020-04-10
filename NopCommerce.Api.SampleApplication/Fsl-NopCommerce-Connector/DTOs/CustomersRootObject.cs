using Newtonsoft.Json;
using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.DTOs
{
    public class CustomersRootObject
    {
        [JsonProperty("customers")]
        public List<CustomerApi> Customers { get; set; }
    }
}
