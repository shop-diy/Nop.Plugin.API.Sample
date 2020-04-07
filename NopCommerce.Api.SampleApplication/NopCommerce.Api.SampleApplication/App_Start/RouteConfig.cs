using System.Web.Mvc;
using System.Web.Routing;

namespace NopCommerce.Api.Connector
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Submit",
               url: "submit",
               defaults: new { controller = "Authorization", action = "Submit" },
               namespaces: new string[] { "NopCommerce.Api.Connector.Controllers" }
           );

            routes.MapRoute(
               name: "GetAccessToken",
               url: "token",
               defaults: new { controller = "Authorization", action = "GetAccessToken" },
               namespaces: new string[] { "NopCommerce.Api.Connector.Controllers" }
            );

            routes.MapRoute(
               name: "RefreshAccessToken",
               url: "refresh_token",
               defaults: new { controller = "Authorization", action = "RefreshAccessToken" },
               namespaces: new string[] { "NopCommerce.Api.Connector.Controllers" }
            );

            routes.MapRoute(
               name: "GetCustomers",
               url: "customers",
               defaults: new { controller = "Customers", action = "GetCustomers" },
               namespaces: new string[] { "NopCommerce.Api.Connector.Controllers" }
            );

            routes.MapRoute(
               name: "GetProducts",
               url: "products",
               defaults: new { controller = "Products", action = "GetProducts" },
               namespaces: new string[] { "NopCommerce.Api.Connector.Controllers" }
            );

            routes.MapRoute(
               name: "UpdateCustomer",
               url: "updatecustomer/{customerId}",
               defaults: new { controller = "Customers", action = "UpdateCustomer", customerId = UrlParameter.Optional },
               namespaces: new string[] { "NopCommerce.Api.Connector.Controllers" }
            );

            routes.MapRoute(
   name: "UpdateProduct",
   url: "updateproduct/{customerId}",
   defaults: new { controller = "Products", action = "UpdateProduct", customerId = UrlParameter.Optional },
   namespaces: new string[] { "NopCommerce.Api.Connector.Controllers" }
);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authorization", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "NopCommerce.Api.Connector.Controllers" }
            );
        }
    }
}
