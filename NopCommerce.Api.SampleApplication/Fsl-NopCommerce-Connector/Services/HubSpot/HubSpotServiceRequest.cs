using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public sealed class HubSpotServiceRequest
    {
        public string Path { get; set; }
        public int Limit { get; set; } = 10;
        public dynamic Properties { get; set; }
        public IEnumerable<string> Associations { get; set; }
        public bool Archived { get; set; }
        public IEnumerable<object> Inputs { get; set; }

        public static HubSpotServiceRequest ForQuote()
        {
            return new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/quotes",
            };
        }

        public HubSpotServiceRequest LimitedTo(int limit)
        {
            Limit = limit;

            return this;
        }

        public HubSpotServiceRequest IncludeProperties(params string[] propertyNames)
        {
            Properties = new HubSpotProperties(propertyNames);

            return this;
        }

        public HubSpotServiceRequest IncludeProperties(IDictionary<string, string> properties)
        {
            Properties = new HubSpotProperties(properties);

            return this;
        }

        public HubSpotServiceRequest WithAssociations(params string[] associations)
        {
            Associations = associations;

            return this;
        }

        public HubSpotServiceRequest WithInputs(object[] inputs)
        {
            Inputs = inputs;

            return this;
        }
    }
}
