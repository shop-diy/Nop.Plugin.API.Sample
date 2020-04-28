using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Fsl.BigCommerce.Api.Connector.Services.Acumatica;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fsl.BigCommerce.Api.Connector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrdersController : ControllerBase
    {
        const string SiteURL = "http://192.168.1.11/ERP/";
        const string Username = "FSLDEVELOPER";
        const string Password = "pb[N7(kA";
        const string Tenant = "FSLTEST";
        const string Branch = null;
        const string Locale = null;
        private const string DefaultEndpoint = @"Custom/17.200.001.1";

        public SalesOrdersController()
        {
        }

        [HttpGet("test")]
        public Task<IActionResult> TestSync()
        {
            return Task.FromResult<IActionResult>(Ok("Sales Order -> Quote Sync"));
        }

        public Task<IActionResult> GetAll()
        {
            var authApi = new AuthApi(SiteURL);

            try
            {
                var config = Login(authApi);

                Console.WriteLine("Reading Sales Orders...");
                var salesOrderApi = new SalesOrderApi(config);

                var salesOrder = salesOrderApi
                    .GetList(filter:"orderType eq 'QT' and orderNbr eq '143188'")
                    ?.FirstOrDefault();

                if (salesOrder == null)
                {
                    return Task.FromResult<IActionResult>(NotFound());
                }

                string customerId = salesOrder.CustomerID.Value;
                var customerApi = new CustomerApi(config);

                var customer = customerApi
                    .GetList(filter: $"CustomerID eq '{customerId}'")
                    ?.FirstOrDefault();

                return Task.FromResult<IActionResult>(Ok(new
                {
                    salesOrder,
                    customer
                }));
                //var so = salesOrderApi.GetByKeys(new List<string> { "orderNbr", "143188" });
                //return Ok(so);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                return Task.FromResult<IActionResult>(base.Problem("An error occurred attempting to process your request."));
            }
            finally
            {
                authApi.AuthLogout();
                Console.WriteLine("Logged Out...");
            }
        }

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
    }
}