using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Services.Acumatica
{
    public abstract class Entity
    {
        /// <summary>
        /// Whether it is needed to delete detail record.
        /// </summary>
        [DataMember(Name = nameof(Delete), EmitDefaultValue = false)]
        public bool? Delete { get; set; }

        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid? ID { get; set; }

        [DataMember(Name = "rowNumber", EmitDefaultValue = false)]
        public long? RowNumber { get; set; }

        [DataMember(Name = "note", EmitDefaultValue = false)]
        public string Note { get; set; }

        public Dictionary<string, Dictionary<string, CustomField>> Custom { get; set; }

        /// <summary>
        /// Gets or Sets Files
        /// </summary>
        [DataMember(Name = "files", EmitDefaultValue = false)]
        public List<FileLink> Files { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return ToJson().ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
