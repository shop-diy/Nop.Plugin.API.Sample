using System;
using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot.Model
{
    public sealed class HubSpotCompany : HubSpotEntity
    {
        /// <summary>
        /// A short statement about the company's mission and goals.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The optional classification of this company record - prospect, partner, etc.
        /// </summary>
        public CompanyType? Type { get; set; }

        /// <summary>
        /// HubSpot owner name for this company or organization.
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// HubSpot owner email for this company or organization.
        /// </summary>
        public string OwnerEmail { get; set; }

        /// <summary>
        /// The street address of the company or organization, including unit number.
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// The additional address of the company or organization.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// The city where the company is located.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The state or region in which the company or organization is located.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The postal or zip code of the company or organization.
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// A company's primary phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The country/region in which the company or organization is located.
        /// </summary>
        public string Country { get; set; }



        /// <summary>
        /// The billing street address of the company or organization, including unit number.
        /// </summary>
        public string BillingAddress1 { get; set; }

        /// <summary>
        /// The billing additional address of the company or organization.
        /// </summary>
        public string BillingAddress2 { get; set; }

        /// <summary>
        /// The billing city where the company is located.
        /// </summary>
        public string BillingCity { get; set; }

        /// <summary>
        /// The billing state or region in which the company or organization is located.
        /// </summary>
        public string BillingState { get; set; }

        /// <summary>
        /// The billing postal or zip code of the company or organization.
        /// </summary>
        public string BillingZip { get; set; }

        /// <summary>
        /// The billing country/region in which the company or organization is located.
        /// </summary>
        public string BillingCountry { get; set; }

        /// <summary>
        /// The main website of the company or organization. This property is used to identify unique companies.
        /// </summary>
        public string WebSite { get; set; }

        /// <summary>
        /// The domain name of the company or organization.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// The total number of employees who work for the company or organization.
        /// </summary>
        public int? EmployeeCount { get; set; }

        /// <summary>
        /// The type of business the company performs. By default, this property has
        /// approximately 150 pre-defined options to select from. While these options
        /// cannot be deleted as they used by HubSpot Insights, you can add new custom
        /// options to meet your needs.
        /// </summary>
        public string Industry { get; set; }

        /// <summary>
        /// The actual or estimated annual revenue of the company.
        /// </summary>
        public decimal? AnnualRevenue { get; set; }

        /// <summary>
        /// The company's sales, prospecting or outreach status.
        /// </summary>
        public string LeadStatus { get; set; }

        /// <summary>
        /// The date the company or organization was closed as a customer.
        /// </summary>
        public DateTime? CloseDate { get; set; }

        public IEnumerable<HubSpotQuote> Quotes { get; set; }
        public IEnumerable<HubSpotLineItem> LineItems { get; set; }
        public IEnumerable<HubSpotContact> Contacts { get; set; }

        internal IEnumerable<string> AssociatedQuoteIds { get; set; }
        internal IEnumerable<string> AssociatedLineItemIds { get; set; }
        internal IEnumerable<string> AssociatedContactIds { get; set; }
        internal IEnumerable<string> AssociatedDealIds { get; set; }
    }
}