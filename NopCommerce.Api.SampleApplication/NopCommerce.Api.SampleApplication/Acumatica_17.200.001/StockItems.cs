using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NopCommerce.Api.AdapterLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace NopCommerce.Api.Connector
{
    public static class StockItems
    {

        public static void Get()
        {


            //https://contou.com/acumatica/rest-api-web-endpoint-quick-guide/
            //https://riptutorial.com/acumatica/example/28801/data-export-in-a-single-rest-call

            ///ERP/entity/Default/17.200.001
            using (RestService service = new RestService(@"http://192.168.1.11/ERP/", @"Default/17.200.001", @"FSLDEVELOPER", @"pb[N7(kA", @"FSLTEST", null))
            {
                string stockItems = service.GetList("StockItem");

                dynamic response = JsonConvert.DeserializeObject(stockItems);

                foreach(var stockItem in response)
                {
                    if (stockItem.ABCCode.value.ToString().Equals("W"))
                    {
                        decimal msrp = 0;
                        var msrpstring = stockItem.MSRP?.value.ToString();
                        if(!string.IsNullOrEmpty(msrpstring))
                        {
                            msrp = decimal.Parse(msrpstring);
                        }
                        var content = stockItem.Content?.value.ToString();

                        var description = stockItem.Description?.value.ToString();
                        var inventoryId = stockItem.InventoryID?.value.ToString();
                        //var itemStatus = stockItem.ItemStatus?.value.ToString();
                        var imageUrl = stockItem.ImageURL?.value.ToString();

                        var product = new { product = new { name = description, full_description = content, price = msrp } };
                        string productJson = JsonConvert.SerializeObject(product);
                    }
                }
            }


        }

    }
}
