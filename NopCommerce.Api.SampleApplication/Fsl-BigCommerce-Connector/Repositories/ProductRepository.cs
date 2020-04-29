using Fsl.BigCommerce.Api.Connector.DTOs;
using Fsl.BigCommerce.Api.Connector.Services;
using Newtonsoft.Json;
using ShopifySharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BigCommerceAPI.PCL;
using BigCommerceAPI.PCL.Models;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using Fsl.NopCommerce.Api.Connector.Model.HubSpot;

namespace Fsl.BigCommerce.Api.Connector.Repositories
{
    public sealed class ProductRepository
    {
        //private readonly BigCommerceAPIClient _api;
        private readonly NopCommerceApiService _api;
        private readonly AcumaticaApiService _acumatica;
        private readonly HubSpotContext _hubSpot;

        public ProductRepository(NopCommerceApiService api, AcumaticaApiService acumatica, HubSpotContext hubSpotContext)
        {
            _hubSpot = hubSpotContext ?? throw new ArgumentNullException(nameof(hubSpotContext));
            _api = api ?? throw new ArgumentNullException(nameof(api));
            _acumatica = acumatica ?? throw new ArgumentNullException(nameof(acumatica));
        }

        public Task Create(ProductApi _entity)
        {
            throw new NotImplementedException();

            //var product = new { product = new { name = "test product" } };
            //string productJson = JsonConvert.SerializeObject(product);
            //await _api.Post($"api/products", productJson);
        }

        public async Task Delete(double id)
        {
            //_api.DeleteProductById(id);
        }

        public async Task<ProductCollectionResponse> GetAll()
        {

            BigCommerceAPIClient apiInstance = new BigCommerceAPIClient("zzr434k017");

            return await apiInstance.Client.GetProductsAsync();

        }

        public Task<ProductApi> GetById(int _id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int _id, ProductApi _updated)
        {
            throw new NotImplementedException();

            //var productToUpdate = new { product = new { name = "product name", price = "1.00" } };
            //string productJson = JsonConvert.SerializeObject(productToUpdate);
            //string jsonUrl = $"api/products/{id}";
            //await _api.Put(jsonUrl, productJson);
        }

        public async Task<object> SyncBigCommerceProductToHubspot(ProductCollectionResponse productsRootObject)
        {

            var bigProducts = productsRootObject.Data.Where(product => !string.IsNullOrEmpty(product.Sku));
            var hsProducts = await _hubSpot.Products.GetAll();

            foreach (var product in bigProducts)
            {
                try
                {
                    var newProduct = new HubSpotProduct
                    {
                        SKU = product.Sku,
                        Name = product.Name,
                        UnitPrice = decimal.Parse(product.Price.Value.ToString()),
                        UnitCost = decimal.Parse(product.CostPrice.Value.ToString()),
                        Description = "https://full-spectrum-laser.mybigcommerce.com/" + product.Name

                    };

                    var exists = hsProducts.Where(p => p.SKU == product.Sku);

                    if (exists.Any())
                    {
                        await _hubSpot.Products.Update(exists.First().Id, newProduct);
                    }
                    else
                    {
                        await _hubSpot.Products.AddNew(newProduct);
                    }
                }
                catch 
                {
                }

            }
            return null;
        }

        
    }
}
