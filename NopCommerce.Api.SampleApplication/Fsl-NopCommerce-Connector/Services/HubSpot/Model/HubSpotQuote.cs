using System;
using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot.Model
{
    public sealed class HubSpotQuote : HubSpotEntity
    {
        /// <summary>
        /// Reference number shown on quote document.
        /// </summary>
        public string QuoteNumber { get; set; }

        /// <summary>
        /// The date that this quote expires.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Any relevant information about pricing, purchasing terms, and/or master agreements.
        /// </summary>
        public string Terms { get; set; }

        /// <summary>
        /// Currency code for the quote.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// The total due for the quote.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Approval status of the quote.
        /// </summary>
        public ApprovalStatus? ApprovalStatus { get; set; }

        /// <summary>
        /// The display style of line item discounts.
        /// </summary>
        public DiscountDisplayStyle? DiscountDisplayStyle { get; set; }

        public IEnumerable<HubSpotLineItem> LineItems { get; set; }
        public IEnumerable<HubSpotCompany> Companies { get; set; }
        public IEnumerable<HubSpotContact> Contacts { get; set; }

        internal IEnumerable<string> AssociatedLineItemIds { get; set; }
        internal IEnumerable<string> AssociatedCompanyIds { get; set; }
        internal IEnumerable<string> AssociatedContactIds { get; set; }
        internal IEnumerable<string> AssociatedDealIds { get; set; }
    }
}
