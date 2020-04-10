using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using HtmlAgilityPack;
using Newtonsoft.Json;
using NopCommerce.Api.AdapterLibrary;
using NopCommerce.Api.Connector.DTOs;

namespace NopCommerce.Api.Connector.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult GetProducts()
        {
            var accessToken = (Session["accessToken"] ?? TempData["accessToken"]).ToString();
            var serverUrl = (Session["serverUrl"] ?? TempData["serverUrl"]).ToString();

            //Get Nop REST client
            var nopApiClient = new ApiClient(accessToken, serverUrl);

            //Get currently listed Nop products
            var jsonUrl = $"/api/products?fields=name,id,sku";
            object productsData = nopApiClient.Get(jsonUrl);
            var productsRootObject = JsonConvert.DeserializeObject<ProductsRootObject>(productsData.ToString());
            var products = productsRootObject.Products.Where(product => !string.IsNullOrEmpty(product.Name));

            string stockItems = null;
            using (RestService service = new RestService(@"http://192.168.1.11/ERP/", @"Default/17.200.001", @"FSLDEVELOPER", @"pb[N7(kA", @"FSLTEST", null))
            {
                stockItems = service.GetList("StockItem");
            }

            dynamic response = JsonConvert.DeserializeObject(stockItems);

            foreach (var stockItem in response)
            {
                var onlineVisible = stockItem.ABCCode?.value?.ToString();
                if (onlineVisible != null && onlineVisible.Equals("W"))
                {
                    decimal msrp = 0;
                    var msrpstring = stockItem.MSRP?.value.ToString();
                    if (!string.IsNullOrEmpty(msrpstring))
                    {
                        msrp = decimal.Parse(msrpstring);
                    }
                    var content = Convert.ToString(stockItem.Content?.value);
                    var description = stockItem.Description?.value.ToString();
                    var inventoryId = stockItem.InventoryID?.value.ToString();
                    //var itemStatus = stockItem.ItemStatus?.value.ToString();
                    var imageUrl = stockItem.ImageURL?.value.ToString();

                    // Remove existing product from Nop
                    foreach (var product in products.Where(i => i.Sku == inventoryId))
                    {

                        object ret = nopApiClient.Delete($"/api/products/{product.Id}");
                    }

                    var a = "-----BEGIN METADATA-----";
                    var b = "-----END METADATA-----";
                    int Pos1 = content.IndexOf(a) + a.Length;
                    int Pos2 = content.IndexOf(b);
                    var metaString = content.Substring(Pos1, Pos2 - Pos1);

                    content = content.Remove(0, Pos2 + b.Length);

                    metaString = System.Net.WebUtility.HtmlDecode(metaString);

                    dynamic meta = JsonConvert.DeserializeObject(metaString);
                    List<string> imageList = new List<string>();
                    foreach (var image in meta.images)
                    {
                        imageList.Add(image.Value.ToString());
                    }

                    var imageType = imageList.Select((value, index) => new { id = index, picture_id = index, position = index, src = value, attachment = "" }).ToList();

                    var productStructure = new
                    {
                        product = new
                        {
                            name = description,
                            full_description = content,
                            price = msrp,
                            sku = inventoryId,
                            //images = new[] { new { id = 0, picture_id = 0, position = 0, src = "http://fsl-public.imgix.net/_accessories/lens/1.5/1.png?auto=format&fit=clip&w=470&h=313", attachment = "" } }
                            images = imageType
                        }
                    };


                    string productJson = JsonConvert.SerializeObject(productStructure);

                    nopApiClient.Post($"/api/products", productJson);
                }
            }


            jsonUrl = $"/api/products?fields=name,id";
            productsData = nopApiClient.Get(jsonUrl);

            productsRootObject = JsonConvert.DeserializeObject<ProductsRootObject>(productsData.ToString());

            products = productsRootObject.Products.Where(product => !string.IsNullOrEmpty(product.Name));

            return View("~/Views/Products.cshtml", products);
        }

        public ActionResult GetProducts2()
        {
            var accessToken = (Session["accessToken"] ?? TempData["accessToken"]).ToString();
            var serverUrl = (Session["serverUrl"] ?? TempData["serverUrl"]).ToString();

            var nopApiClient = new ApiClient(accessToken, serverUrl);

            var jsonUrl = $"/api/products?fields=name,id";
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


            var productToUpdate = new { product = new { name = "product name", price = "1.00" } };
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