using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Fsl.NopCommerce.Api.Connector.Services.Acumatica
{
    /// <summary>
    /// CustomShortField
    /// </summary>
    [DataContract]
    public partial class CustomShortField : CustomField, IEquatable<CustomShortField>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomShortField" /> class.
        /// </summary>
        [JsonConstructor]
        protected CustomShortField() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomShortField" /> class.
        /// </summary>
        /// <param name="value">value.</param>
        public CustomShortField(int? value = default, string type = default) : base(type)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public int? Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CustomShortField {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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
            return Equals(input as CustomShortField);
        }

        /// <summary>
        /// Returns true if CustomShortField instances are equal
        /// </summary>
        /// <param name="input">Instance of CustomShortField to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CustomShortField input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                (
                    Value == input.Value ||
                    (Value != null &&
                    Value.Equals(input.Value))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode() =>
            HashCode.Combine(base.GetHashCode(), (Value?.GetHashCode()).GetValueOrDefault());

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            foreach (var x in BaseValidate(validationContext)) yield return x;
            yield break;
        }
    }
}