using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
//using System.Web.Script.Serialization;

namespace Fsl.NopCommerce.Api.Connector
{
    public class AcumaticaApiService : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _acumaticaBaseUrl;
        private readonly string _acumaticaEndpointUrl;

        public AcumaticaApiService(string acumaticaBaseUrl, string endpoint,
            string userName, string password,
            string company, string branch)
        {
            _acumaticaBaseUrl = acumaticaBaseUrl;
            _acumaticaEndpointUrl = _acumaticaBaseUrl + "/entity/" + endpoint + "/";
            _httpClient = new HttpClient(
                new HttpClientHandler
                {
                    UseCookies = true,
                    CookieContainer = new CookieContainer()
                })
            {
                BaseAddress = new Uri(_acumaticaEndpointUrl),
                DefaultRequestHeaders =
            {
                Accept = {MediaTypeWithQualityHeaderValue.Parse("text/json")}
            }
            };

            //var str = new StringContent(
            //    new JavaScriptSerializer()
            //        .Serialize(
            //            new
            //            {
            //                name = userName,
            //                password = password,
            //                company = company,
            //                branch = branch
            //            }),
            //            Encoding.UTF8, "application/json");

            var str = JsonConvert.SerializeObject(new
            {
                name = userName,
                password = password,
                company = company,
                branch = branch
            });

            var content = new StringContent(str, Encoding.UTF8, "application/json");

            _httpClient.PostAsync(acumaticaBaseUrl + "/entity/auth/login", content)
                .Result.EnsureSuccessStatusCode();
        }

        void IDisposable.Dispose()
        {
            _httpClient.PostAsync(_acumaticaBaseUrl + "/entity/auth/logout",
                new ByteArrayContent(new byte[0])).Wait();
            _httpClient.Dispose();
        }

        public string GetList(string entityName)
        {
            var res = _httpClient.GetAsync(_acumaticaEndpointUrl + entityName)
                .Result.EnsureSuccessStatusCode();

            return res.Content.ReadAsStringAsync().Result;
        }

        public string GetList(string entityName, string parameters)
        {
            var res = _httpClient.GetAsync(_acumaticaEndpointUrl + entityName + "?" + parameters)
                .Result.EnsureSuccessStatusCode();

            return res.Content.ReadAsStringAsync().Result;
        }
    }
}