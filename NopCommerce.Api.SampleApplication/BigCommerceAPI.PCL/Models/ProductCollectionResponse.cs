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
    public class ProductCollectionResponse : INotifyPropertyChanged 
    {
        // These fields hold the values for the public properties.
        private List<Product> data;
        private CollectionMeta meta;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("data")]
        public List<Product> Data 
        { 
            get 
            {
                return this.data; 
            } 
            set 
            {
                this.data = value;
                onPropertyChanged("Data");
            }
        }

        /// <summary>
        /// Data about the response, including pagination and collection totals.
        /// </summary>
        [JsonProperty("meta")]
        public CollectionMeta Meta 
        { 
            get 
            {
                return this.meta; 
            } 
            set 
            {
                this.meta = value;
                onPropertyChanged("Meta");
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