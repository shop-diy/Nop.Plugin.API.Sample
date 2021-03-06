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
    public class Links : INotifyPropertyChanged 
    {
        // These fields hold the values for the public properties.
        private string current;
        private string next;
        private string previous;

        /// <summary>
        /// Link to the current page returned in the response.
        /// </summary>
        [JsonProperty("current")]
        public string Current 
        { 
            get 
            {
                return this.current; 
            } 
            set 
            {
                this.current = value;
                onPropertyChanged("Current");
            }
        }

        /// <summary>
        /// Link to the next page returned in the response.
        /// </summary>
        [JsonProperty("next")]
        public string Next 
        { 
            get 
            {
                return this.next; 
            } 
            set 
            {
                this.next = value;
                onPropertyChanged("Next");
            }
        }

        /// <summary>
        /// Link to the previous page returned in the response.
        /// </summary>
        [JsonProperty("previous")]
        public string Previous 
        { 
            get 
            {
                return this.previous; 
            } 
            set 
            {
                this.previous = value;
                onPropertyChanged("Previous");
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