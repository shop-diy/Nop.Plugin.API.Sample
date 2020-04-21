using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public interface IHubSpotServiceRequest
    {
        bool Archived { get; set; }
        IEnumerable<string> Associations { get; set; }
        IEnumerable<object> Inputs { get; set; }
        int Limit { get; set; }
        string Path { get; set; }
        dynamic Properties { get; set; }

        IHubSpotServiceRequest IncludeProperties(IDictionary<string, string> properties);
        IHubSpotServiceRequest IncludeProperties(params string[] propertyNames);
        IHubSpotServiceRequest LimitedTo(int limit);
        IHubSpotServiceRequest WithAssociations(params string[] associations);
        IHubSpotServiceRequest WithInputs(object[] inputs);
    }
}