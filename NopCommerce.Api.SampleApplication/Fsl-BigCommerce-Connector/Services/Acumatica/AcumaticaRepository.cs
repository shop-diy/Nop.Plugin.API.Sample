using System;
using System.Net;

namespace Fsl.BigCommerce.Api.Connector.Services.Acumatica
{
    public sealed class AcumaticaRepository : IDisposable
    {
        const string SiteURL = "http://192.168.1.11/ERP/";
        const string Username = "FSLDEVELOPER";
        const string Password = "pb[N7(kA";
        const string Tenant = "FSLTEST";
        const string Branch = null;
        const string Locale = null;
        private const string DefaultEndpoint = @"Custom/17.200.001.1";

        private readonly AuthApi _authApi;
        private readonly Lazy<SalesOrderApi> _salesOrders;
        private readonly Lazy<CustomerApi> _customers;
        private readonly Lazy<ContactApi> _contacts;

        public AcumaticaRepository()
        {
            _authApi = new AuthApi(SiteURL);

            var config = Login(_authApi);

            _salesOrders = new Lazy<SalesOrderApi>(() => new SalesOrderApi(config));
            _customers = new Lazy<CustomerApi>(() => new CustomerApi(config));
            _contacts = new Lazy<ContactApi>(() => new ContactApi(config));
        }

        public SalesOrderApi SalesOrders => _salesOrders.Value;
        public CustomerApi Customers => _customers.Value;
        public ContactApi Contacts => _contacts.Value;

        private Configuration Login(AuthApi authApi)
        {
            var cookieContainer = new CookieContainer();
            authApi.Configuration.ApiClient.RestClient.CookieContainer = cookieContainer;

            authApi.AuthLogin(new Credentials(Username, Password, Tenant, Branch, Locale));

            Console.WriteLine("Logged in...");

            var configuration = new Configuration($"{SiteURL}entity/{DefaultEndpoint}/");

            configuration.ApiClient.RestClient.CookieContainer = authApi.Configuration.ApiClient.RestClient.CookieContainer;

            return configuration;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _authApi.AuthLogout();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AcumaticaRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
