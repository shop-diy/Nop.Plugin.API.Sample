using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;

namespace Fsl.NopCommerce.Api.Connector.Services.Acumatica
{
    /// <summary>
    /// CustomField
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(CustomIntField), "CustomIntField")]
    [JsonSubtypes.KnownSubType(typeof(CustomStringField), "CustomStringField")]
    [JsonSubtypes.KnownSubType(typeof(CustomBooleanField), "CustomBooleanField")]
    [JsonSubtypes.KnownSubType(typeof(CustomByteField), "CustomByteField")]
    [JsonSubtypes.KnownSubType(typeof(CustomDateTimeField), "CustomDateTimeField")]
    [JsonSubtypes.KnownSubType(typeof(CustomDoubleField), "CustomDoubleField")]
    [JsonSubtypes.KnownSubType(typeof(CustomShortField), "CustomShortField")]
    [JsonSubtypes.KnownSubType(typeof(CustomLongField), "CustomLongField")]
    [JsonSubtypes.KnownSubType(typeof(CustomDecimalField), "CustomDecimalField")]
    [JsonSubtypes.KnownSubType(typeof(CustomGuidField), "CustomGuidField")]
    public partial class CustomField : IEquatable<CustomField>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomField" /> class.
        /// </summary>
        [JsonConstructor]
        protected CustomField() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomField" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        public CustomField(string type = default)
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for CustomField and cannot be null");
            }
            else
            {
                Type = type;
            }
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [Obsolete("viewName property is for backward compatibility with SOAP only. Please use Custom property of Entity instead.")]
        public string viewName;

        [Obsolete("fieldName property is for backward compatibility with SOAP only. Please use Custom property of Entity instead.")]
        public string fieldName;

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CustomField {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as CustomField);
        }

        /// <summary>
        /// Returns true if CustomField instances are equal
        /// </summary>
        /// <param name="input">Instance of CustomField to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CustomField input)
        {
            if (input == null)
                return false;

            return
                (
                    Type == input.Type ||
                    (Type != null &&
                    Type.Equals(input.Type))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode() =>
            HashCode.Combine(41, Type.GetHashCode());

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            return BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<ValidationResult> BaseValidate(ValidationContext _)
        {
            yield break;
        }
    }
}
