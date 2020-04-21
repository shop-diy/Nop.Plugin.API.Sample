using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    static class HubSpotServiceExtensions
    {
        private static readonly JsonSerializerSettings _settings;

        static HubSpotServiceExtensions()
        {
            _settings = new JsonSerializerSettings();
            _settings.Converters.Add(new HubSpotPropertiesConverter());
        }

        public static async Task<IHubSpotServiceResponse<T>> Call<T>(this IHubSpotService service, HttpMethod method, IHubSpotServiceRequest request) where T : class, new()
        {
            var response = await service.Call(method, request);

            T dataObject = default;

            if (response.Status == HttpStatusCode.OK && !string.IsNullOrWhiteSpace(response.Data))
            {
                dataObject = JsonConvert.DeserializeObject<T>(response.Data, _settings);
            }

            return new HubSpotServiceResponse<T>(response.Status, dataObject);
        }

        public static Task<IHubSpotServiceResponse<T>> Get<T>(this IHubSpotService service, IHubSpotServiceRequest request) where T : class, new()
        {
            return Call<T>(service, HttpMethod.Get, request);
        }

        public static Task<IHubSpotServiceResponse<T>> Post<T>(this IHubSpotService service, IHubSpotServiceRequest request) where T : class, new()
        {
            return Call<T>(service, HttpMethod.Post, request);
        }

        public static Task<IHubSpotServiceResponse<T>> Put<T>(this IHubSpotService service, IHubSpotServiceRequest request) where T : class, new()
        {
            return Call<T>(service, HttpMethod.Put, request);
        }

        public static Task<IHubSpotServiceResponse<T>> Delete<T>(this IHubSpotService service, IHubSpotServiceRequest request) where T : class, new()
        {
            return Call<T>(service, HttpMethod.Delete, request);
        }
    }
}
