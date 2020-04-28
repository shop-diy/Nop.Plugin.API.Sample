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
    public class CategoryNode : INotifyPropertyChanged 
    {
        // These fields hold the values for the public properties.
        private List<CategoryNode> children;
        private int? id;
        private bool? isVisible;
        private string name;
        private int? parentId;
        private string url;

        /// <summary>
        /// The list of children of the category.
        /// </summary>
        [JsonProperty("children")]
        public List<CategoryNode> Children 
        { 
            get 
            {
                return this.children; 
            } 
            set 
            {
                this.children = value;
                onPropertyChanged("Children");
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
        /// The custom url for the category on the store front.
        /// </summary>
        [JsonProperty("url")]
        public string Url 
        { 
            get 
            {
                return this.url; 
            } 
            set 
            {
                this.url = value;
                onPropertyChanged("Url");
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