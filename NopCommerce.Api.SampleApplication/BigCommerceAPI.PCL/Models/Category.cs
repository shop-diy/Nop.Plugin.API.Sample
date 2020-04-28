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
    public class Category : INotifyPropertyChanged 
    {
        // These fields hold the values for the public properties.
        private string customUrl;
        private DefaultProductSortEnum? defaultProductSort;
        private string description;
        private int? id;
        private string imageFile;
        private bool? isVisible;
        private string layoutFile;
        private string metaDescription;
        private List<string> metaKeywords;
        private string name;
        private string pageTitle;
        private int? parentId;
        private string searchKeywords;
        private int? sort;
        private int? views;

        /// <summary>
        /// The custom url for the category on the store front.
        /// </summary>
        [JsonProperty("custom_url")]
        public string CustomUrl 
        { 
            get 
            {
                return this.customUrl; 
            } 
            set 
            {
                this.customUrl = value;
                onPropertyChanged("CustomUrl");
            }
        }

        /// <summary>
        /// Determines how the products are sorted on category page load.
        /// </summary>
        [JsonProperty("default_product_sort", ItemConverterType = typeof(StringValuedEnumConverter))]
        public DefaultProductSortEnum? DefaultProductSort 
        { 
            get 
            {
                return this.defaultProductSort; 
            } 
            set 
            {
                this.defaultProductSort = value;
                onPropertyChanged("DefaultProductSort");
            }
        }

        /// <summary>
        /// The product description which can include HTML formatting.
        /// </summary>
        [JsonProperty("description")]
        public string Description 
        { 
            get 
            {
                return this.description; 
            } 
            set 
            {
                this.description = value;
                onPropertyChanged("Description");
            }
        }

        /// <summary>
        /// The unique numeric ID of the category, increments sequentially.
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
        /// URL of the image file shown for this category on the storefront. Images can be uploaded to /categories/{categoryId}/image.
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
        /// Flag to determine if the product should be displayed to customers browsing the store or not. If true the category will be displayed, false the category will be hidden from view.
        /// </summary>
        [JsonProperty("is_visible")]
        public bool? IsVisible 
        { 
            get 
            {
                return this.isVisible; 
            } 
            set 
            {
                this.isVisible = value;
                onPropertyChanged("IsVisible");
            }
        }

        /// <summary>
        /// The layout template file used to render this category.
        /// </summary>
        [JsonProperty("layout_file")]
        public string LayoutFile 
        { 
            get 
            {
                return this.layoutFile; 
            } 
            set 
            {
                this.layoutFile = value;
                onPropertyChanged("LayoutFile");
            }
        }

        /// <summary>
        /// Custom meta description for the category page, if not defined the store default meta description will be used.
        /// </summary>
        [JsonProperty("meta_description")]
        public string MetaDescription 
        { 
            get 
            {
                return this.metaDescription; 
            } 
            set 
            {
                this.metaDescription = value;
                onPropertyChanged("MetaDescription");
            }
        }

        /// <summary>
        /// Custom meta keywords for the category page, if not defined the store default keywords will be used. Must post as an array like: ["awesome","sauce"]
        /// </summary>
        [JsonProperty("meta_keywords")]
        public List<string> MetaKeywords 
        { 
            get 
            {
                return this.metaKeywords; 
            } 
            set 
            {
                this.metaKeywords = value;
                onPropertyChanged("MetaKeywords");
            }
        }

        /// <summary>
        /// The name displayed for the category. Name is unique to the category's siblings.
        /// </summary>
        [JsonProperty("name")]
        public string Name 
        { 
            get 
            {
                return this.name; 
            } 
            set 
            {
                this.name = value;
                onPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Custom title for the category page, if not defined the category name will be used as the meta title.
        /// </summary>
        [JsonProperty("page_title")]
        public string PageTitle 
        { 
            get 
            {
                return this.pageTitle; 
            } 
            set 
            {
                this.pageTitle = value;
                onPropertyChanged("PageTitle");
            }
        }

        /// <summary>
        /// The unique numeric ID of the category's parent. This field controls where the category sits in the tree of categories that organize the catalog.
        /// </summary>
        [JsonProperty("parent_id")]
        public int? ParentId 
        { 
            get 
            {
                return this.parentId; 
            } 
            set 
            {
                this.parentId = value;
                onPropertyChanged("ParentId");
            }
        }

        /// <summary>
        /// A comma separated list of keywords that can be used to locate the category when searching the store.
        /// </summary>
        [JsonProperty("search_keywords")]
        public string SearchKeywords 
        { 
            get 
            {
                return this.searchKeywords; 
            } 
            set 
            {
                this.searchKeywords = value;
                onPropertyChanged("SearchKeywords");
            }
        }

        /// <summary>
        /// Priority this category will be given when included in the menu and category pages. The lower the number, the closer to the top of the results the category will be.
        /// </summary>
        [JsonProperty("sort")]
        public int? Sort 
        { 
            get 
            {
                return this.sort; 
            } 
            set 
            {
                this.sort = value;
                onPropertyChanged("Sort");
            }
        }

        /// <summary>
        /// Number of views the category has on the storefront
        /// </summary>
        [JsonProperty("views")]
        public int? Views 
        { 
            get 
            {
                return this.views; 
            } 
            set 
            {
                this.views = value;
                onPropertyChanged("Views");
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