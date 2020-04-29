using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    sealed class HubSpotService : IHubSpotService
    {
        private const string ServerUrl = "https://api.hubapi.com/";
        private const string API = "crm";
        private const string ApiKey = "87f8ef85-0af6-45fc-9d99-87728e94153a";
        private static readonly JsonConverter enumConverter = new Newtonsoft.Json.Converters.StringEnumConverter();

        private readonly HttpClient _httpClient;
        public HubSpotService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IHubSpotServiceResponse> Call(HttpMethod method, IHubSpotServiceRequest request)
        {
            var uri = new UriBuilder($"{ServerUrl}{request.Path}");
            var queryBuilder = new StringBuilder();
            if (method == HttpMethod.Get)
            {
                var limit = request.Limit > 0 ? request.Limit : 10;

                queryBuilder.Append($"limit={limit}");
                queryBuilder.Append($"&archived={request.Archived}");

                if (request.Associations != null)
                {
                    queryBuilder.Append($"&associations={string.Join(',', request.Associations)}");
                }

                if (request.Properties != null && method == HttpMethod.Get)
                {
                    var propNames = (IEnumerable<string>)request.Properties?.GetDynamicMemberNames();

                    if (propNames != null && propNames.Count() > 0)
                    {
                        queryBuilder.Append($"&properties={string.Join(',', propNames)}");
                    }
                }
                queryBuilder.Append($"&hapikey={ApiKey}");
            }
            else
            {
                queryBuilder.Append($"hapikey={ApiKey}");
            }

            uri.Query = queryBuilder.ToString();

            var httpRequest = new HttpRequestMessage(method, uri.Uri);

            if (method == HttpMethod.Post || method == HttpMethod.Put || method == HttpMethod.Patch)
            {
                string json = null;
                if (request.Properties != null)
                {
                    if (request.Inputs != null)
                    {
                        string[] properties = request.Properties.GetDynamicMemberNames();
                        json = JsonConvert.SerializeObject(new
                        {
                            properties,
                            inputs = request.Inputs
                        }, enumConverter);
                    }
                    else
                    {
                        var properties = request.Properties as Dictionary<string, object>;

                        json = JsonConvert.SerializeObject(new
                        {
                            properties
                        }, enumConverter);
                    }
                }
                else if (request.Inputs != null)
                {
                    json = JsonConvert.SerializeObject(new
                    {
                        inputs = request.Inputs
                    }, enumConverter);
                }

                if (!string.IsNullOrEmpty(json))
                {
                    httpRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }
            }

            var httpResponse = await _httpClient.SendAsync(httpRequest);

            httpResponse.EnsureSuccessStatusCode();

            string data = null;

            if (httpResponse.Content != null)
            {
                data = await httpResponse.Content.ReadAsStringAsync();
            }

            return new HubSpotServiceResponse(httpResponse.StatusCode, data);
        }

        public Task<IHubSpotServiceResponse> Get(IHubSpotServiceRequest request)
        {
            return Call(HttpMethod.Get, request);
        }

        public Task<IHubSpotServiceResponse> Post(IHubSpotServiceRequest request)
        {
            return Call(HttpMethod.Post, request);
        }

        public Task<IHubSpotServiceResponse> Put(IHubSpotServiceRequest request)
        {
            return Call(HttpMethod.Put, request);
        }

        public Task<IHubSpotServiceResponse> Patch(IHubSpotServiceRequest request)
        {
            return Call(HttpMethod.Patch, request);
        }

        public Task<IHubSpotServiceResponse> Delete(IHubSpotServiceRequest request)
        {
            return Call(HttpMethod.Delete, request);
        }
    }
}
