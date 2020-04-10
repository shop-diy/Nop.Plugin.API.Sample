using Fsl.NopCommerce.Api.Connector.DTOs;
using Fsl.NopCommerce.Api.Connector.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Repositories
{
    public sealed class ProductRepository
    {
        private readonly NopCommerceApiService _api;

        public ProductRepository(NopCommerceApiService api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
        }

        public async Task Create(ProductApi entity)
        {
            throw new NotImplementedException();

            var product = new { product = new { name = "test product" } };
            string productJson = JsonConvert.SerializeObject(product);
            await _api.Post($"/api/products", productJson);
        }

        public async Task Delete(int id)
        {
            await _api.Delete($"/api/products/{id}");
        }

        public async Task<ProductsRootObject> GetAll()
        {
            var jsonUrl = $"/api/products?fields=name,id,sku";
            object productsData = await _api.Get(jsonUrl);
            var productsRootObject = JsonConvert.DeserializeObject<ProductsRootObject>(productsData.ToString());
            return productsRootObject;
        }

        public Task<ProductApi> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, ProductApi updated)
        {
            throw new NotImplementedException();

            var productToUpdate = new { product = new { name = "product name", price = "1.00" } };
            string productJson = JsonConvert.SerializeObject(productToUpdate);
            string jsonUrl = $"/api/products/{id}";
            await _api.Put(jsonUrl, productJson);
        }

        public async Task SyncProducts()
        {
            //Get currently listed Nop products
            var productsRootObject = await GetAll();
            var products = productsRootObject.Products.Where(product => !string.IsNullOrEmpty(product.Name));

            // Get all Acumatica products
            string stockItems = null;
            using (AcumaticaApiService service = new AcumaticaApiService(@"http://192.168.1.11/ERP/", @"Default/17.200.001", @"FSLDEVELOPER", @"pb[N7(kA", @"FSLTEST", null))
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

                    // Remove existing product from Nop catalog
                    foreach (var product in products.Where(i => i.Sku == inventoryId))
                    {
                        await Delete(int.Parse(product.Id));
                    }

                    // Get product image links from Acu Description Field
                    var a = "-----BEGIN METADATA-----";
                    var b = "-----END METADATA-----";
                    int Pos1 = content.IndexOf(a) + a.Length;
                    int Pos2 = content.IndexOf(b);
                    var metaString = content.Substring(Pos1, Pos2 - Pos1);
                    metaString = System.Net.WebUtility.HtmlDecode(metaString);
                    dynamic meta = JsonConvert.DeserializeObject(metaString);
                    List<string> imageList = new List<string>();
                    foreach (var image in meta.images)
                    {
                        imageList.Add(image.Value.ToString());
                    }
                    var imageType = imageList.Select((value, index) => new { id = index, picture_id = index, position = index, src = value, attachment = "" }).ToList();

                    // Remove metadata from the rest of description
                    content = content.Remove(0, Pos2 + b.Length);

                    // build product listing
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

                    await _api.Post($"/api/products", productJson);
                }
            }
        }
    }
}
