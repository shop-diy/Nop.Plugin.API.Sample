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
    public class Adjuster : INotifyPropertyChanged 
    {
        // These fields hold the values for the public properties.
        private Adjuster37Enum? adjuster;
        private double? adjusterValue;

        /// <summary>
        /// The type of adjuster – either `relative` or `percentage` – for the variant's price or weight, when the modifier value is selected on the storefront.
        /// </summary>
        [JsonProperty("adjuster", ItemConverterType = typeof(StringValuedEnumConverter))]
        public Adjuster37Enum? AdjusterProp 
        { 
            get 
            {
                return this.adjuster; 
            } 
            set 
            {
                this.adjuster = value;
                onPropertyChanged("AdjusterProp");
            }
        }

        /// <summary>
        /// The numeric amount by which the adjuster will change the variant's price or the weight, when the modifier value is selected on the storefront. 
        /// </summary>
        [JsonProperty("adjuster_value")]
        public double? AdjusterValue 
        { 
            get 
            {
                return this.adjusterValue; 
            } 
            set 
            {
                this.adjusterValue = value;
                onPropertyChanged("AdjusterValue");
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