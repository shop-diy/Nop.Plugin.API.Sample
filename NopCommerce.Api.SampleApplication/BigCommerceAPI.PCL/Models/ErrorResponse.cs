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
    public class ErrorResponse : INotifyPropertyChanged 
    {
        // These fields hold the values for the public properties.
        private object errors;
        private string instance;
        private int? status;
        private string title;
        private string type;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("errors")]
        public object Errors 
        { 
            get 
            {
                return this.errors; 
            } 
            set 
            {
                this.errors = value;
                onPropertyChanged("Errors");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("instance")]
        public string Instance 
        { 
            get 
            {
                return this.instance; 
            } 
            set 
            {
                this.instance = value;
                onPropertyChanged("Instance");
            }
        }

        /// <summary>
        /// The HTTP status code
        /// </summary>
        [JsonProperty("status")]
        public int? Status 
        { 
            get 
            {
                return this.status; 
            } 
            set 
            {
                this.status = value;
                onPropertyChanged("Status");
            }
        }

        /// <summary>
        /// Error title describing the particular error encountered.
        /// </summary>
        [JsonProperty("title")]
        public string Title 
        { 
            get 
            {
                return this.title; 
            } 
            set 
            {
                this.title = value;
                onPropertyChanged("Title");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("type")]
        public string Type 
        { 
            get 
            {
                return this.type; 
            } 
            set 
            {
                this.type = value;
                onPropertyChanged("Type");
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