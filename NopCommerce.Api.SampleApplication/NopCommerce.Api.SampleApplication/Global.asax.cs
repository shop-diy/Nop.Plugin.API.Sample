using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.Routing;

namespace NopCommerce.Api.Connector
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            //var hj = "[{\"product_id\":123,\"name\":\"stack\"},{\"product_id\":456,\"name\":\"overflow\"}]";

            //dynamic gg = JsonConvert.DeserializeObject(hj);

            //foreach(var h in gg)
            //{

            //}

            //var productStructure = new
            //{
            //    product = new
            //    {
            //        name = "name",
            //        //full_description = content,
            //        price = "msrp",
            //        sku = "id",
            //        images = new[] { new { id = 42, picture_id = 0, position = 0, src = "", attachment = "" } }
            //    }
            //};

            //string productJson = JsonConvert.SerializeObject(productStructure);
        }
    }
}
