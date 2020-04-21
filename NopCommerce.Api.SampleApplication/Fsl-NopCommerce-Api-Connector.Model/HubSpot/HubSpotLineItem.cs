using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Model.HubSpot
{
    [DataContract]
    public sealed class HubSpotLineItem : HubSpotEntity
    {
        // Use "Description" property for name. Default "Line Item {PositionOnQuote}"

        /// <summary>
        /// Unique product identifier.
        /// </summary>
        [DataMember(Name = nameof(SKU), EmitDefaultValue = true)]
        public string SKU { get; set; }

        /// <summary>
        /// ID of the product from which this was copied.
        /// </summary>
        [DataMember(Name = nameof(ProductId), EmitDefaultValue = true)]
        public string ProductId { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        [DataMember(Name = nameof(ProductName), EmitDefaultValue = true)]
        public string ProductName { get; set; }

        /// <summary>
        /// The cost of the product.
        /// </summary>
        [DataMember(Name = nameof(UnitPrice), EmitDefaultValue = true)]
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// How many units of a product are in this line item.
        /// </summary>
        [DataMember(Name = nameof(Quantity), EmitDefaultValue = true)]
        public int? Quantity { get; set; }

        /// <summary>
        /// The tax amount applied.
        /// </summary>
        [DataMember(Name = nameof(Tax), EmitDefaultValue = false)]
        public decimal? Tax { get; set; }

        /// <summary>
        /// The amount that sold goods cost the customer.
        /// </summary>
        [DataMember(Name = nameof(UnitCost), EmitDefaultValue = false)]
        public decimal? UnitCost { get; set; }

        /// <summary>
        /// The amount of a line item.
        /// </summary>
        [DataMember(Name = nameof(Amount), EmitDefaultValue = true)]
        public decimal? Amount { get; set; }

        /// <summary>
        /// The discount amount applied.
        /// </summary>
        [DataMember(Name = nameof(Discount), EmitDefaultValue = false)]
        public decimal? Discount { get; set; }

        /// <summary>
        /// The discount percentage applied.
        /// </summary>
        [DataMember(Name = nameof(DiscountPercentage), EmitDefaultValue = false)]
        public float? DiscountPercentage { get; set; }

        /// <summary>
        /// Currency code for the line item.
        /// </summary>
        [DataMember(Name = nameof(Currency), EmitDefaultValue = false)]
        public string Currency { get; set; }

        /// <summary>
        /// The order which the line item appears on the quotes.
        /// </summary>
        [DataMember(Name = nameof(PositionOnQuote), EmitDefaultValue = false)]
        public int? PositionOnQuote { get; set; }

        [IgnoreDataMember]
        public IEnumerable<HubSpotQuote> Quotes { get; set; }
        [IgnoreDataMember]
        public IEnumerable<HubSpotCompany> Companies { get; set; }
        [IgnoreDataMember]
        public IEnumerable<HubSpotContact> Contacts { get; set; }

        [DataMember(Name = nameof(AssociatedQuoteIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedQuoteIds { get; set; }

        [DataMember(Name = nameof(AssociatedCompanyIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedCompanyIds { get; set; }

        [DataMember(Name = nameof(AssociatedContactIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedContactIds { get; set; }

        [DataMember(Name = nameof(AssociatedDealIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedDealIds { get; set; }
    }
}