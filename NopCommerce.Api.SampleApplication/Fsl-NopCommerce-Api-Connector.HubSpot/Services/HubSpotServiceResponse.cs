using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using System.Net;

namespace Fsl.NopCommerce.Api.Connector.Services
{
    class HubSpotServiceResponse : IHubSpotServiceResponse
    {
        public HubSpotServiceResponse(HttpStatusCode status, string data)
        {
            Status = status;
            Data = data;
        }
        public HttpStatusCode Status { get; }

        public string Data { get; }
    }

    class HubSpotServiceResponse<T> : HubSpotServiceResponse, IHubSpotServiceResponse<T> where T : class, new()
    {
        public HubSpotServiceResponse(HttpStatusCode status, T data): base(status, null)
        {
            Data = data;
        }

        new public T Data { get; }
    }
}
