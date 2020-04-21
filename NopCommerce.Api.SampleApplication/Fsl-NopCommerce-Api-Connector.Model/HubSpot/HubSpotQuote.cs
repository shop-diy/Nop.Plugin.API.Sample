using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Model.HubSpot
{
    [DataContract]
    public sealed class HubSpotQuote : HubSpotEntity
    {
        /// <summary>
        /// Reference number shown on quote document.
        /// </summary>
        [DataMember(Name = nameof(QuoteNumber), EmitDefaultValue = true)]
        public string QuoteNumber { get; set; }

        /// <summary>
        /// The date that this quote expires.
        /// </summary>
        [DataMember(Name = nameof(ExpirationDate), EmitDefaultValue = false)]
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Any relevant information about pricing, purchasing terms, and/or master agreements.
        /// </summary>
        [DataMember(Name = nameof(Terms), EmitDefaultValue = false)]
        public string Terms { get; set; }

        /// <summary>
        /// Currency code for the quote.
        /// </summary>
        [DataMember(Name = nameof(Currency), EmitDefaultValue = false)]
        public string Currency { get; set; }

        /// <summary>
        /// The total due for the quote.
        /// </summary>
        [DataMember(Name = nameof(Amount), EmitDefaultValue = false)]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Approval status of the quote.
        /// </summary>
        [DataMember(Name = nameof(ApprovalStatus), EmitDefaultValue = false)]
        public ApprovalStatus? ApprovalStatus { get; set; }

        /// <summary>
        /// The display style of line item discounts.
        /// </summary>
        [DataMember(Name = nameof(DiscountDisplayStyle), EmitDefaultValue = false)]
        public DiscountDisplayStyle? DiscountDisplayStyle { get; set; }

        [IgnoreDataMember]
        public IEnumerable<HubSpotLineItem> LineItems { get; set; }
        [IgnoreDataMember]
        public IEnumerable<HubSpotCompany> Companies { get; set; }
        [IgnoreDataMember]
        public IEnumerable<HubSpotContact> Contacts { get; set; }

        [DataMember(Name = nameof(AssociatedLineItemIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedLineItemIds { get; set; }

        [DataMember(Name = nameof(AssociatedCompanyIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedCompanyIds { get; set; }

        [DataMember(Name = nameof(AssociatedContactIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedContactIds { get; set; }

        [DataMember(Name = nameof(AssociatedDealIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedDealIds { get; set; }
    }
}
