﻿using Fsl.NopCommerce.Api.Connector.DTOs;
using Fsl.NopCommerce.Api.Connector.Services;
using Newtonsoft.Json;
using ShopifySharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Repositories
{
    public sealed class ProductRepository
    {
        private readonly NopCommerceApiService _api;
        private readonly AcumaticaApiService _acumatica;

        public ProductRepository(NopCommerceApiService api, AcumaticaApiService acumatica)
        {
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

        public async Task Delete(int id)
        {
            await _api.Delete($"api/products/{id}");
        }

        public async Task<ProductsRootObject> GetAll()
        {
            var jsonUrl = $"api/products?fields=name,id,sku";
            var (statusCode, data) = await _api.Get<ProductsRootObject>(jsonUrl);

            if ((int)statusCode < 299 && (int)statusCode > 199)
            {
                return data;
            }

            return null;
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

        public async Task<object> SyncAcuProductsToNopCommerce(ProductsRootObject productsRootObject = null)
        {
            //Get currently listed Nop products
            productsRootObject ??= await GetAll();
            var products = productsRootObject.Products.Where(product => !string.IsNullOrEmpty(product.Name));

            // Get all Acumatica products
            string stockItems = _acumatica.GetList("StockItem");

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

                    // When picture_id = 0 the API will add a new picture, otherwise it will try to replace a picture with the given id.
                    // In this case we want to add a new one, because it will simply delete any unused pictures to synchronize
                    var imageType = imageList.Select((value, index) => new { id = index, picture_id = 0, position = index + 1, src = value, attachment = "" }).ToList();

                    // Remove metadata from the rest of description
                    content = content.Remove(0, Pos2 + b.Length);

                    // build product listing
                    var productStructure = new
                    {
                        product = new
                        {
                            name = description,
                            //full_description = content,
                            price = msrp,
                            sku = inventoryId,
                            //images = new[] { new { id = 0, picture_id = 0, position = 0, src = "http://fsl-public.imgix.net/_accessories/lens/1.5/1.png?auto=format&fit=clip&w=470&h=313", attachment = "" } }
                            images = imageType
                        }
                    };

                    //string productJson = JsonConvert.SerializeObject(productStructure);

                    try
                    {
                        var (statusCode, data) = await _api.Post($"api/products", productStructure);
                    }
                    catch (HttpRequestException exHttpRequest)
                    {
                        Console.WriteLine($"HTTP REQUEST EXCEPTION: {exHttpRequest.Message}");
                    }
                    catch (WebException webEx)
                    {
                        Console.WriteLine($"ERROR: {webEx.Message}");
                        var exResponse = (HttpWebResponse)webEx.Response;
                        Console.WriteLine($"STATUS: {exResponse.StatusCode}");
                    }
                    catch (Exception ex)
                    {
                        var exType = ex.GetType();
                        Console.WriteLine($"{exType.Name}: {ex.Message}");
                    }
   
                }
            }
             return null;
        }

        public async Task<object> SyncAcuProductsToShopify(ProductsRootObject productsRootObject = null)
        {
            productsRootObject = new ProductsRootObject();


            //Get currently listed Nop products
            //productsRootObject ??= await GetAll();
            var products = new List<ProductApi>();// productsRootObject.Products.Where(product => !string.IsNullOrEmpty(product.Name));

            // Get all Acumatica products
            string stockItems = _acumatica.GetList("StockItem");

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

                    // When picture_id = 0 the API will add a new picture, otherwise it will try to replace a picture with the given id.
                    // In this case we want to add a new one, because it will simply delete any unused pictures to synchronize
                    var imageType = imageList.Select((value, index) => new { id = index, picture_id = 0, position = index + 1, src = value, attachment = "" }).ToList();

                    // Remove metadata from the rest of description
                    content = content.Remove(0, Pos2 + b.Length);

                    // build product listing
                    var productStructure = new
                    {
                        product = new
                        {
                            name = description,
                            //full_description = content,
                            price = msrp,
                            sku = inventoryId,
                            //images = new[] { new { id = 0, picture_id = 0, position = 0, src = "http://fsl-public.imgix.net/_accessories/lens/1.5/1.png?auto=format&fit=clip&w=470&h=313", attachment = "" } }
                            images = imageType
                        }
                    };

                    //string productJson = JsonConvert.SerializeObject(productStructure);

                    try
                    {

                        var service = new ProductService("https://fslaser.myshopify.com/", "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");
                        var product = new Product()
                        {
                            Title = "Burton Custom Freestlye 151",
                            Vendor = "Burton",
                            BodyHtml = "<strong>Good snowboard!</strong>",
                            ProductType = "Snowboard",
                            Images = new List<ProductImage>
                            {
                                new ProductImage
                                {
                                    Attachment = "R0lGODlhAQABAIAAAAAAAAAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw=="
                                }
                            },

                        };

                        var g = await service.ListAsync();

                        product = await service.CreateAsync(product);

                        return product;
                        //var (statusCode, data) = await _api.Post($"api/products", productStructure);
                    }
                    catch (HttpRequestException exHttpRequest)
                    {
                        Console.WriteLine($"HTTP REQUEST EXCEPTION: {exHttpRequest.Message}");
                    }
                    catch (WebException webEx)
                    {
                        Console.WriteLine($"ERROR: {webEx.Message}");
                        var exResponse = (HttpWebResponse)webEx.Response;
                        Console.WriteLine($"STATUS: {exResponse.StatusCode}");
                    }
                    catch (Exception ex)
                    {
                        var exType = ex.GetType();
                        Console.WriteLine($"{exType.Name}: {ex.Message}");
                    }


                }
            }
            return null;
        }
    }
}
