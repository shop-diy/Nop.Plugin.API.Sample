using Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public class HubSpotService
    {
        private const string ServerUrl = "https://api.hubapi.com/";
        private const string API = "crm";
        private const string ApiKey = "87f8ef85-0af6-45fc-9d99-87728e94153a";

        private readonly HttpClient _httpClient;
        public HubSpotService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<(HttpStatusCode Status, string Data)> Call(HttpMethod method, HubSpotServiceRequest request)
        {
            var uri = new UriBuilder($"{ServerUrl}{request.Path}");
            var queryBuilder = new StringBuilder();
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

            uri.Query = queryBuilder.ToString();

            var httpRequest = new HttpRequestMessage(method, uri.Uri);

            if (method == HttpMethod.Post || method == HttpMethod.Put)
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
                        });
                    }
                    else
                    {
                        json = JsonConvert.SerializeObject(new
                        {
                            properties = request.Properties.GetDynamicMemberNames().ToArray(),
                            inputs = request.Inputs
                        });
                    }
                }
                else if (request.Inputs != null)
                {
                    json = JsonConvert.SerializeObject(new
                    {
                        inputs = request.Inputs
                    });
                }

                if (!string.IsNullOrEmpty(json))
                {
                    httpRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }
            }

            var httpResponse = await _httpClient.SendAsync(httpRequest);

            httpResponse.EnsureSuccessStatusCode();

            string Data = null;

            if (httpResponse.Content != null)
            {
                Data = await httpResponse.Content.ReadAsStringAsync();
            }

            return (Status: httpResponse.StatusCode, Data);
        }

        public async Task<(HttpStatusCode Status, T Data)> Call<T>(HttpMethod method, HubSpotServiceRequest request)
        {
            (HttpStatusCode Status, string Data) = await Call(method, request);

            T dataObject = default;

            if (Status == HttpStatusCode.OK && !string.IsNullOrWhiteSpace(Data))
            {
                dataObject = JsonConvert.DeserializeObject<T>(Data, _settings);
            }

            return (Status, dataObject);
        }

        private static readonly JsonSerializerSettings _settings;
        
        static HubSpotService()
        {
            _settings = new JsonSerializerSettings();
            _settings.Converters.Add(new HubSpotPropertiesConverter());
        }

        public Task<(HttpStatusCode Status, string Data)> Get(HubSpotServiceRequest request)
        {
            return Call(HttpMethod.Get, request);
        }

        public Task<(HttpStatusCode Status, T Data)> Get<T>(HubSpotServiceRequest request)
        {
            return Call<T>(HttpMethod.Get, request);
        }

        public Task<(HttpStatusCode Status, string Data)> Post(HubSpotServiceRequest request)
        {
            return Call(HttpMethod.Post, request);
        }

        public Task<(HttpStatusCode Status, T Data)> Post<T>(HubSpotServiceRequest request)
        {
            return Call<T>(HttpMethod.Post, request);
        }

        public Task<(HttpStatusCode Status, string Data)> Put(HubSpotServiceRequest request)
        {
            return Call(HttpMethod.Put, request);
        }

        public Task<(HttpStatusCode Status, T Data)> Put<T>(HubSpotServiceRequest request)
        {
            return Call<T>(HttpMethod.Put, request);
        }

        public Task<(HttpStatusCode Status, string Data)> Delete(HubSpotServiceRequest request)
        {
            return Call(HttpMethod.Delete, request);
        }

        public Task<(HttpStatusCode Status, T Data)> Delete<T>(HubSpotServiceRequest request)
        {
            return Call<T>(HttpMethod.Delete, request);
        }
    }
}
