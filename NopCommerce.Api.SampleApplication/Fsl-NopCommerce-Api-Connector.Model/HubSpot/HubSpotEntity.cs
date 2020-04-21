using System;
using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Model.HubSpot
{
    [DataContract]
    public abstract class HubSpotEntity
    {
        /// <summary>
        /// The unique identifier for this item.
        /// </summary>
        [DataMember(Name = nameof(Id), EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// The name of this item.
        /// </summary>
        [DataMember(Name = nameof(Name), EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// The date/time this item was created.
        /// </summary>
        [DataMember(Name = nameof(CreatedDate), EmitDefaultValue = true)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date/time this item was last updated.
        /// </summary>
        [DataMember(Name = nameof(UpdatedDate), EmitDefaultValue = true)]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Whether or not this item has been archived.
        /// </summary>
        [DataMember(Name = nameof(IsArchived), EmitDefaultValue = true)]
        public bool IsArchived { get; set; }
    }
}
