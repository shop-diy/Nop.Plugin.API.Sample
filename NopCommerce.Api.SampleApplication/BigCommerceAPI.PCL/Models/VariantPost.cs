/*
 * BigCommerceAPI.PCL
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ) on 04/27/2020
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using BigCommerceAPI.PCL;
using BigCommerceAPI.PCL.Utilities;

namespace BigCommerceAPI.PCL.Models
{
    public class VariantPost : INotifyPropertyChanged 
    {
        // These fields hold the values for the public properties.
        private string binPickingNumber;
        private string costPrice;
        private int? id;
        private string imageFile;
        private int? inventoryLevel;
        private int? inventoryWarningLevel;
        private List<OptionValueShortPost> optionValues;
        private string price;
        private int? productId;
        private bool? purchasingDisabled;
        private string purchasingDisabledMessage;
        private string sku;
        private int? skuId;
        private string upc;
        private string weight;

        /// <summary>
        /// Identifies where in a warehouse the variant is located.
        /// </summary>
        [JsonProperty("bin_picking_number")]
        public string BinPickingNumber 
        { 
            get 
            {
                return this.binPickingNumber; 
            } 
            set 
            {
                this.binPickingNumber = value;
                onPropertyChanged("BinPickingNumber");
            }
        }

        /// <summary>
        /// The variant's cost price
        /// </summary>
        [JsonProperty("cost_price")]
        public string CostPrice 
        { 
            get 
            {
                return this.costPrice; 
            } 
            set 
            {
                this.costPrice = value;
                onPropertyChanged("CostPrice");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("id")]
        public int? Id 
        { 
            get 
            {
                return this.id; 
            } 
            set 
            {
                this.id = value;
                onPropertyChanged("Id");
            }
        }

        /// <summary>
        /// The image that will be displayed when this variant is selected on the storefront. When updating a SKU image, send the publicly accessible URL. Supported image formats are JPEG, PNG, and GIF. Generic product images not specific to the variant should be stored on the product.
        /// </summary>
        [JsonProperty("image_file")]
        public string ImageFile 
        { 
            get 
            {
                return this.imageFile; 
            } 
            set 
            {
                this.imageFile = value;
                onPropertyChanged("ImageFile");
            }
        }

        /// <summary>
        /// Inventory level for the variant, which is used when the product's inventory_tracking is set to variant
        /// </summary>
        [JsonProperty("inventory_level")]
        public int? InventoryLevel 
        { 
            get 
            {
                return this.inventoryLevel; 
            } 
            set 
            {
                this.inventoryLevel = value;
                onPropertyChanged("InventoryLevel");
            }
        }

        /// <summary>
        /// When the variant hits this inventory level it is considered low stock
        /// </summary>
        [JsonProperty("inventory_warning_level")]
        public int? InventoryWarningLevel 
        { 
            get 
            {
                return this.inventoryWarningLevel; 
            } 
            set 
            {
                this.inventoryWarningLevel = value;
                onPropertyChanged("InventoryWarningLevel");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("option_values")]
        public List<OptionValueShortPost> OptionValues 
        { 
            get 
            {
                return this.optionValues; 
            } 
            set 
            {
                this.optionValues = value;
                onPropertyChanged("OptionValues");
            }
        }

        /// <summary>
        /// This variant's base price on the storefront. If this value is null, the product's default price (set in the Product resource's price field) will be used as the base price.
        /// </summary>
        [JsonProperty("price")]
        public string Price 
        { 
            get 
            {
                return this.price; 
            } 
            set 
            {
                this.price = value;
                onPropertyChanged("Price");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("product_id")]
        public int? ProductId 
        { 
            get 
            {
                return this.productId; 
            } 
            set 
            {
                this.productId = value;
                onPropertyChanged("ProductId");
            }
        }

        /// <summary>
        /// If true, this variant will not be purchasable on the storefront
        /// </summary>
        [JsonProperty("purchasing_disabled")]
        public bool? PurchasingDisabled 
        { 
            get 
            {
                return this.purchasingDisabled; 
            } 
            set 
            {
                this.purchasingDisabled = value;
                onPropertyChanged("PurchasingDisabled");
            }
        }

        /// <summary>
        /// If purchasing_disabled is true, this message should show on the storefront when the variant is selected
        /// </summary>
        [JsonProperty("purchasing_disabled_message")]
        public string PurchasingDisabledMessage 
        { 
            get 
            {
                return this.purchasingDisabledMessage; 
            } 
            set 
            {
                this.purchasingDisabledMessage = value;
                onPropertyChanged("PurchasingDisabledMessage");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("sku")]
        public string Sku 
        { 
            get 
            {
                return this.sku; 
            } 
            set 
            {
                this.sku = value;
                onPropertyChanged("Sku");
            }
        }

        /// <summary>
        /// read-only reference to V2 sku id, null if it's a base variant
        /// </summary>
        [JsonProperty("sku_id")]
        public int? SkuId 
        { 
            get 
            {
                return this.skuId; 
            } 
            set 
            {
                this.skuId = value;
                onPropertyChanged("SkuId");
            }
        }

        /// <summary>
        /// The UPC code which is used in feeds for shopping comparison sites and external channel integrations
        /// </summary>
        [JsonProperty("upc")]
        public string Upc 
        { 
            get 
            {
                return this.upc; 
            } 
            set 
            {
                this.upc = value;
                onPropertyChanged("Upc");
            }
        }

        /// <summary>
        /// This variant's base weight on the storefront. If this value is null, the product's default weight (set in the Product resource's weight field) will be used as the base weight.
        /// </summary>
        [JsonProperty("weight")]
        public string Weight 
        { 
            get 
            {
                return this.weight; 
            } 
            set 
            {
                this.weight = value;
                onPropertyChanged("Weight");
            }
        }

        /// <summary>
        /// Property changed event for observer pattern
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises event when a property is changed
        /// </summary>
        /// <param name="propertyName">Name of the changed property</param>
        protected void onPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
} 