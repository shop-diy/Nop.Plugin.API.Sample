/*
 * BigCommerceAPI.PCL
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ) on 04/27/2020
 */
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using BigCommerceAPI.PCL;
using BigCommerceAPI.PCL.Utilities;

namespace BigCommerceAPI.PCL.Models
{
    [JsonConverter(typeof(StringValuedEnumConverter))]
    public enum DateLimitModeEnum
    {
        EARLIEST, //TODO: Write general description for this method
        RANGE, //TODO: Write general description for this method
        LATEST, //TODO: Write general description for this method
    }

    /// <summary>
    /// Helper for the enum type DateLimitModeEnum
    /// </summary>
    public static class DateLimitModeEnumHelper
    {
        //string values corresponding the enum elements
        private static List<string> stringValues = new List<string> { "earliest", "range", "latest" };

        /// <summary>
        /// Converts a DateLimitModeEnum value to a corresponding string value
        /// </summary>
        /// <param name="enumValue">The DateLimitModeEnum value to convert</param>
        /// <returns>The representative string value</returns>
        public static string ToValue(DateLimitModeEnum enumValue)
        {
            switch(enumValue)
            {
                //only valid enum elements can be used
                //this is necessary to avoid errors
                case DateLimitModeEnum.EARLIEST:
                case DateLimitModeEnum.RANGE:
                case DateLimitModeEnum.LATEST:
                    return stringValues[(int)enumValue];

                //an invalid enum value was requested
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert a list of DateLimitModeEnum values to a list of strings
        /// </summary>
        /// <param name="enumValues">The list of DateLimitModeEnum values to convert</param>
        /// <returns>The list of representative string values</returns>
        public static List<string> ToValue(List<DateLimitModeEnum> enumValues)
        {
            if (null == enumValues)
                return null;

            return enumValues.Select(eVal => ToValue(eVal)).ToList();
        }

        /// <summary>
        /// Converts a string value into DateLimitModeEnum value
        /// </summary>
        /// <param name="value">The string value to parse</param>
        /// <returns>The parsed DateLimitModeEnum value</returns>
        public static DateLimitModeEnum ParseString(string value)
        {
            int index = stringValues.IndexOf(value);
            if(index < 0)
                throw new InvalidCastException(string.Format("Unable to cast value: {0} to type DateLimitModeEnum", value));

            return (DateLimitModeEnum) index;
        }
    }
} 