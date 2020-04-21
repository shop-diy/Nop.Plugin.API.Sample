using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public sealed class HubSpotServiceRequest : IHubSpotServiceRequest
    {
        public string Path { get; set; }
        public int Limit { get; set; } = 10;
        public dynamic Properties { get; set; }
        public IEnumerable<string> Associations { get; set; }
        public bool Archived { get; set; }
        public IEnumerable<object> Inputs { get; set; }

        public static IHubSpotServiceRequest ForQuote()
        {
            return new HubSpotServiceRequest
            {
                Path = "crm/v3/objects/quotes",
            };
        }

        public IHubSpotServiceRequest LimitedTo(int limit)
        {
            Limit = limit;

            return this;
        }

        public IHubSpotServiceRequest IncludeProperties(params string[] propertyNames)
        {
            Properties = new HubSpotProperties(propertyNames);

            return this;
        }

        public IHubSpotServiceRequest IncludeProperties(IDictionary<string, string> properties)
        {
            Properties = new HubSpotProperties(properties);

            return this;
        }

        public IHubSpotServiceRequest WithAssociations(params string[] associations)
        {
            Associations = associations;

            return this;
        }

        public IHubSpotServiceRequest WithInputs(object[] inputs)
        {
            Inputs = inputs;

            return this;
        }
    }
}
