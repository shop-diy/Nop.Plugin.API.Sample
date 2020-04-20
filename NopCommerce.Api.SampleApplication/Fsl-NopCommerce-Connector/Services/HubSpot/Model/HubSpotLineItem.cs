using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot.Model
{
    public sealed class HubSpotLineItem : HubSpotEntity
    {
        // Use "Description" property for name. Default "Line Item {PositionOnQuote}"

        /// <summary>
        /// Unique product identifier.
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// ID of the product from which this was copied.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The cost of the product.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// How many units of a product are in this line item.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// The tax amount applied.
        /// </summary>
        public decimal? Tax { get; set; }

        /// <summary>
        /// The amount that sold goods cost the customer.
        /// </summary>
        public decimal? UnitCost { get; set; }

        /// <summary>
        /// The amount of a line item.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// The discount amount applied.
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// The discount percentage applied.
        /// </summary>
        public float? DiscountPercentage { get; set; }

        /// <summary>
        /// Currency code for the line item.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// The order which the line item appears on the quotes.
        /// </summary>
        public int? PositionOnQuote { get; set; }

        public IEnumerable<HubSpotQuote> Quotes { get; set; }
        public IEnumerable<HubSpotCompany> Companies { get; set; }
        public IEnumerable<HubSpotContact> Contacts { get; set; }

        internal IEnumerable<string> AssociatedQuoteIds { get; set; }
        internal IEnumerable<string> AssociatedCompanyIds { get; set; }
        internal IEnumerable<string> AssociatedContactIds { get; set; }
        internal IEnumerable<string> AssociatedDealIds { get; set; }
    }
}