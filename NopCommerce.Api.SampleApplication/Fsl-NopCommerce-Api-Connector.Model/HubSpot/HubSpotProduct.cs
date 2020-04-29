using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Model.HubSpot
{
    [DataContract]
    public sealed class HubSpotProduct : HubSpotEntity
    {
        /// <summary>
        /// The unique identifier for this product.
        /// </summary>
        [DataMember(Name = nameof(SKU), EmitDefaultValue = true)]
        public string SKU { get; set; }

        /// <summary>
        /// Full description of this product.
        /// </summary>
        [DataMember(Name = nameof(Description), EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The price of this product.
        /// </summary>
        [DataMember(Name = nameof(UnitPrice), EmitDefaultValue = false)]
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// The amount that sold goods cost the customer.
        /// </summary>
        [DataMember(Name = nameof(UnitCost), EmitDefaultValue = false)]
        public decimal? UnitCost { get; set; }

        /// <summary>
        /// The discount amount applied to this product.
        /// </summary>
        [DataMember(Name = nameof(UnitDiscount), EmitDefaultValue = false)]
        public decimal? UnitDiscount { get; set; }

        /// <summary>
        /// The discount percentage for this product.
        /// </summary>
        [DataMember(Name = nameof(DiscountPercentage), EmitDefaultValue = false)]
        public float? DiscountPercentage { get; set; }

        /// <summary>
        /// The ID of the folder that contains this product.
        /// </summary>
        [DataMember(Name = nameof(FolderId), EmitDefaultValue = false)]
        public string FolderId { get; set; }

        /// <summary>
        /// How frequently the product is billed. The billing frequency here will inform the pricing calculation for deals and quotes.
        /// </summary>
        [DataMember(Name = nameof(BillingFrequency), EmitDefaultValue = false)]
        public BillingFrequency? BillingFrequency { get; set; }

        /// <summary>
        /// The tax amount applied to this product.
        /// </summary>
        [DataMember(Name = nameof(Tax), EmitDefaultValue = false)]
        public decimal? Tax { get; set; }
    }
}
