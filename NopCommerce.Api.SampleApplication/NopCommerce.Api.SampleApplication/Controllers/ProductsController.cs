using System.Dynamic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using NopCommerce.Api.AdapterLibrary;
using NopCommerce.Api.SampleApplication.DTOs;

namespace NopCommerce.Api.SampleApplication.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult GetProducts()
        {
            // TODO: Here you should get the data from your database instead of the current Session.
            // Note: This should not be done in the action! This is only for illustration purposes.
            var accessToken = (Session["accessToken"] ?? TempData["accessToken"]).ToString();
            var serverUrl = (Session["serverUrl"] ?? TempData["serverUrl"]).ToString();

            var nopApiClient = new ApiClient(accessToken, serverUrl);

            string jsonUrl = $"/api/products?fields=name,id";
            object productsData = nopApiClient.Get(jsonUrl);

            var productsRootObject = JsonConvert.DeserializeObject<ProductsRootObject>(productsData.ToString());

            var products = productsRootObject.Products.Where(product => !string.IsNullOrEmpty(product.Name));

            return View("~/Views/Products.cshtml", products);
        }

        //[Route("/api/products/{id}")]
        public ActionResult UpdateProduct(string id)
        {
            id = "42";

            var accessToken = (Session["accessToken"] ?? TempData["accessToken"]).ToString();
            var serverUrl = (Session["serverUrl"] ?? TempData["serverUrl"]).ToString();

            var nopApiClient = new ApiClient(accessToken, serverUrl);

            // we use anonymous type as we want to update only the last_name of the customer
            // also the customer shoud be the cutomer property of a holder object as explained in the documentation
            // https://github.com/SevenSpikes/api-plugin-for-nopcommerce/blob/nopcommerce-3.80/Customers.md#update-details-for-a-customer
            // i.e: { customer : { last_name: "" } }
            var productToUpdate = new { product = new { name = "test", price = "1.00" } };
            string productJson = JsonConvert.SerializeObject(productToUpdate);

            string jsonUrl = $"/api/products/{id}";

            nopApiClient.Put(jsonUrl, productJson);

            return RedirectToAction("GetProducts");
        }

        //  [Route("/api/products")]
        public ActionResult CreateProduct(string name)
        {
            var accessToken = (Session["accessToken"] ?? TempData["accessToken"]).ToString();
            var serverUrl = (Session["serverUrl"] ?? TempData["serverUrl"]).ToString();

            var nopApiClient = new ApiClient(accessToken, serverUrl);


            var product = new { product = new { name = "test product" } };
            string productJson = JsonConvert.SerializeObject(product);

            string jsonUrl = $"/api/products";

            nopApiClient.Post(jsonUrl, productJson);

            return RedirectToAction("GetProducts");
        }
    }
}