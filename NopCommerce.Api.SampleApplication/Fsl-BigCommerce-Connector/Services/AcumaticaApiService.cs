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

namespace Fsl.BigCommerce.Api.Connector
{
    public class AcumaticaApiService : IDisposable
    {
        private const string DefaultAcumaticaBaseUrl = @"http://192.168.1.11/ERP/";
        private const string DefaultEndpoint = @"Custom/17.200.001.1";
        private const string DefaultUsername = @"FSLDEVELOPER";
        private const string DefaultPassword = @"pb[N7(kA";
        private const string DefaultCompany = @"FSLTEST";
        private const string DefaultBranch = null;

        private readonly HttpClient _httpClient;
        private readonly string _acumaticaBaseUrl;
        private readonly string _acumaticaEndpointUrl;

        public AcumaticaApiService(HttpClient httpClient)
        {
            _acumaticaBaseUrl = DefaultAcumaticaBaseUrl;
            _acumaticaEndpointUrl = _acumaticaBaseUrl + "/entity/" + DefaultEndpoint + "/";

            httpClient.BaseAddress = new Uri(_acumaticaEndpointUrl);

            _httpClient = httpClient;

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
                name = DefaultUsername,
                password = DefaultPassword,
                company = DefaultCompany,
                branch = DefaultBranch
            });

            using var content = new StringContent(str, Encoding.UTF8, "application/json");

            _httpClient.PostAsync(_acumaticaBaseUrl + "/entity/auth/login", content)
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