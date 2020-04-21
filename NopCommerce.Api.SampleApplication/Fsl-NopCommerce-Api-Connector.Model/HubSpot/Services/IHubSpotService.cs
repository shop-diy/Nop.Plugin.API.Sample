using System.Net.Http;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public interface IHubSpotService
    {
        Task<IHubSpotServiceResponse> Call(HttpMethod method, IHubSpotServiceRequest request);
        Task<IHubSpotServiceResponse> Delete(IHubSpotServiceRequest request);
        Task<IHubSpotServiceResponse> Get(IHubSpotServiceRequest request);
        Task<IHubSpotServiceResponse> Post(IHubSpotServiceRequest request);
        Task<IHubSpotServiceResponse> Put(IHubSpotServiceRequest request);
    }
}