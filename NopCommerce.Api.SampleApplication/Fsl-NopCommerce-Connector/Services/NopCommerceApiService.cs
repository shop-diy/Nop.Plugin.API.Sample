using Fsl.NopCommerce.Api.Connector.Models;
using Fsl.NopCommerce.Api.Connector.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services
{
    public sealed class NopCommerceApiService
    {
        private const string ClientId = "8c105a5c-6597-4991-b1c9-f249087659eb";
        private const string ClientSecret = "0677922b-ec11-49f0-b280-06af667f7994";
        private const string ServerUrl = "https://fslportal.azurewebsites.net";
        //private const string ServerUrl = "http://localhost:15536/";
        private const string JsonContentType = "application/json";

        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NopCommerceApiService(
            HttpClient httpClient,
            IMemoryCache cache,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.BaseAddress = new Uri(ServerUrl);
            httpClient.DefaultRequestHeaders.Remove("Accept");
            httpClient.DefaultRequestHeaders.Add("Accept", JsonContentType);
            httpClient.DefaultRequestHeaders.Add("User-Agent", GetType().Assembly.GetName().Name);

            _httpClient = httpClient;
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public Task<(HttpStatusCode statusCode, string data)> Call(HttpMethod method, string path)
        {
            return Call(method, path, string.Empty);
        }

        public async Task<(HttpStatusCode statusCode, string data)> Call(HttpMethod method, string path, object callParams)
        {
            using var httpResponse = await GetResponse(method, path, callParams);

            httpResponse.EnsureSuccessStatusCode();

            var data = await httpResponse.Content.ReadAsStringAsync();

            return (statusCode: httpResponse.StatusCode, data);
        }

        public Task<(HttpStatusCode statusCode, T data)> Call<T>(HttpMethod method, string path)
        {
            return Call<T>(method, path, string.Empty);
        }

        public async Task<(HttpStatusCode statusCode, T data)> Call<T>(HttpMethod method, string path, object callParams)
        {
            using var httpResponse = await GetResponse(method, path, callParams);

            //httpResponse.EnsureSuccessStatusCode();

            T data = default;

            if (httpResponse.Content != null)
            {
                using var responseStream = await httpResponse.Content.ReadAsStreamAsync();

                var serializer = new JsonSerializer();

                using var sr = new StreamReader(responseStream);
                using var jsonTextReader = new JsonTextReader(sr);

                data = serializer.Deserialize<T>(jsonTextReader);
            }

            return (statusCode: httpResponse.StatusCode, data);
        }

        public Task<(HttpStatusCode statusCode, string data)> Get(string path)
        {
            return Get(path, null);
        }

        public Task<(HttpStatusCode statusCode, string data)> Get(string path, NameValueCollection callParams)
        {
            return Call(HttpMethod.Get, path, callParams);
        }

        public Task<(HttpStatusCode statusCode, T data)> Get<T>(string path)
        {
            return Get<T>(path, null);
        }

        public Task<(HttpStatusCode statusCode, T data)> Get<T>(string path, NameValueCollection callParams)
        {
            return Call<T>(HttpMethod.Get, path, callParams);
        }

        public Task<(HttpStatusCode statusCode, string data)> Post(string path, object data)
        {
            return Call(HttpMethod.Post, path, data);
        }

        public Task<(HttpStatusCode statusCode, T data)> Post<T>(string path, object data)
        {
            return Call<T>(HttpMethod.Post, path, data);
        }

        public Task<(HttpStatusCode statusCode, string data)> Put(string path, object data)
        {
            return Call(HttpMethod.Put, path, data);
        }

        public Task<(HttpStatusCode statusCode, T data)> Put<T>(string path, object data)
        {
            return Call<T>(HttpMethod.Put, path, data);
        }

        public Task<(HttpStatusCode statusCode, string data)> Delete(string path)
        {
            return Call(HttpMethod.Delete, path);
        }

        public Task<(HttpStatusCode statusCode, T data)> Delete<T>(string path)
        {
            return Call<T>(HttpMethod.Delete, path);
        }

        public string CreateUrl(string subPath)
        {
            var request = _httpContextAccessor.HttpContext.Request;

            return request != null
                ? $"{request.Scheme}://{request.Host}{request.PathBase}/{subPath}"
                : subPath;
        }

        private Task<HttpResponseMessage> GetResponse(HttpMethod method, string path, object callParams)
        {
            string requestUriString = $"{ServerUrl}/{path}";

            if (callParams != null && (method == HttpMethod.Get || method == HttpMethod.Delete))
            {
                requestUriString += $"?{callParams}";
            }

            var httpRequest = new HttpRequestMessage(method, requestUriString);
            var accessToken = GetAccessToken();

            if (!string.IsNullOrEmpty(accessToken))
            {
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            if (callParams != null)
            {
                if (method == HttpMethod.Post || method == HttpMethod.Put)
                {
                    var httpContent = CreateHttpContent(callParams);

                    if (httpContent != null)
                    {
                        httpRequest.Content = httpContent;
                    }
                }
            }

            return _httpClient
                .SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead);
        }

        private string GetAccessToken()
        {
            // TODO: Here you should get the data from your database instead of the current Session.
            // Note: This should not be done in the action! This is only for illustration purposes.
            if (!_cache.TryGetValue<string>("accessToken", out var accessToken))
            {
                var result = Login();

                if (result?.AccessToken != null)
                {
                    _cache.Set("accessToken", result.AccessToken);

                    accessToken = result.AccessToken;
                }
            }

            return accessToken;
        }

        private AuthorizationModel Login()
        {
            AuthorizationModel loginResult = null;

            var nopAuthorizationManager = new AuthorizationManager(ClientId, ClientSecret, ServerUrl);
            var redirectUrl = CreateUrl("token");
            var state = Guid.NewGuid().ToString();
            var authUrl = nopAuthorizationManager.BuildAuthUrl(redirectUrl, new string[] { }, state);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(authUrl);

            httpWebRequest.Method = "GET";
            httpWebRequest.AllowAutoRedirect = false;
            HttpWebResponse httpWebResponse = null;
            int statusCode = 0;
            string uriString = null;

            try
            {
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                statusCode = (int)httpWebResponse.StatusCode;
                uriString = httpWebResponse.Headers["Location"];
            }
            catch (WebException webEx)
            {
                httpWebResponse = webEx.Response as HttpWebResponse;
                statusCode = (int)httpWebResponse?.StatusCode;
                uriString = httpWebResponse?.Headers["Location"];
            }
            finally
            {
                httpWebResponse?.Close();
            }

            if (statusCode >= 300 && statusCode <= 399 && !string.IsNullOrWhiteSpace(uriString))
            {
                var uri = new Uri(uriString);
                var uriParams = uri.Query.TrimStart('?').Split('&').Select(p =>
                {
                    var subStrings = p.Split('=');

                    return new KeyValuePair<string, string>(subStrings[0], subStrings[1]);
                }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                if (uriParams.TryGetValue("code", out var code) &&
                    uriParams.TryGetValue("state", out var returnedState) &&
                    state == returnedState)
                {
                    var authParameters = new AuthParameters()
                    {
                        ClientId = ClientId,
                        ClientSecret = ClientSecret,
                        ServerUrl = ServerUrl,
                        RedirectUrl = redirectUrl,
                        GrantType = "authorization_code",
                        Code = code,
                    };

                    string responseJson = nopAuthorizationManager.GetAuthorizationData(authParameters);

                    loginResult = JsonConvert.DeserializeObject<AuthorizationModel>(responseJson);
                }
            }

            return loginResult;
        }

        private static HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                string json = JsonConvert.SerializeObject(content);
                httpContent = new StringContent(json, Encoding.UTF8, JsonContentType);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue(JsonContentType);
            }

            return httpContent;
        }

    }
}
