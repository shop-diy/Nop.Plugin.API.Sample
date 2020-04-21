using System.Net;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public interface IHubSpotServiceResponse
    {
        public HttpStatusCode Status { get; }
        public string Data { get; }
    }

    public interface IHubSpotServiceResponse<T> : IHubSpotServiceResponse where T : class, new()
    {
        new public T Data { get; }
    }
}
