using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Fsl.BigCommerce.Api.Connector.Services.Acumatica
{
    /// <summary>
    /// DecimalValue
    /// </summary>
    [DataContract]
    public partial class DecimalValue : IEquatable<DecimalValue>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalValue" /> class.
        /// </summary>
        /// <param name="value">value.</param>
        public DecimalValue(decimal? value = default)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public decimal? Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DecimalValue {\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return Equals(input as DecimalValue);
        }

        /// <summary>
        /// Returns true if DecimalValue instances are equal
        /// </summary>
        /// <param name="input">Instance of DecimalValue to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DecimalValue input)
        {
            if (input == null)
                return false;

            return
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
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Value);

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}