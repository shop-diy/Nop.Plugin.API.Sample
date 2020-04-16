using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services
{
    public sealed partial class AuthorizationClientFactory
    {
        private readonly HttpClient _httpClient;
        public AuthorizationClientFactory(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public IAuthorizationClient Create(string clientId, string clientSecret, string serverUrl)
        {
            throw new NotImplementedException();
        }
    }
}
