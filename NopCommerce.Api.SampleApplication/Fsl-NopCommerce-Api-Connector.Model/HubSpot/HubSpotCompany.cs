using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Model.HubSpot
{
    [DataContract]
    public sealed class HubSpotCompany : HubSpotEntity
    {
        /// <summary>
        /// A short statement about the company's mission and goals.
        /// </summary>
        [DataMember(Name = nameof(Description), EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The optional classification of this company record - prospect, partner, etc.
        /// </summary>
        [DataMember(Name = nameof(Type), EmitDefaultValue = false)]
        public CompanyType? Type { get; set; }

        /// <summary>
        /// HubSpot owner name for this company or organization.
        /// </summary>
        [DataMember(Name = nameof(OwnerName), EmitDefaultValue = false)]
        public string OwnerName { get; set; }

        /// <summary>
        /// HubSpot owner email for this company or organization.
        /// </summary>
        [DataMember(Name = nameof(OwnerEmail), EmitDefaultValue = false)]
        public string OwnerEmail { get; set; }

        /// <summary>
        /// The street address of the company or organization, including unit number.
        /// </summary>
        [DataMember(Name = nameof(Address1), EmitDefaultValue = true)]
        public string Address1 { get; set; }

        /// <summary>
        /// The additional address of the company or organization.
        /// </summary>
        [DataMember(Name = nameof(Address2), EmitDefaultValue = true)]
        public string Address2 { get; set; }

        /// <summary>
        /// The city where the company is located.
        /// </summary>
        [DataMember(Name = nameof(City), EmitDefaultValue = true)]
        public string City { get; set; }

        /// <summary>
        /// The state or region in which the company or organization is located.
        /// </summary>
        [DataMember(Name = nameof(State), EmitDefaultValue = true)]
        public string State { get; set; }

        /// <summary>
        /// The postal or zip code of the company or organization.
        /// </summary>
        [DataMember(Name = nameof(Zip), EmitDefaultValue = true)]
        public string Zip { get; set; }

        /// <summary>
        /// A company's primary phone number.
        /// </summary>
        [DataMember(Name = nameof(Phone), EmitDefaultValue = false)]
        public string Phone { get; set; }

        /// <summary>
        /// The country/region in which the company or organization is located.
        /// </summary>
        [DataMember(Name = nameof(Country), EmitDefaultValue = true)]
        public string Country { get; set; }

        /// <summary>
        /// The billing street address of the company or organization, including unit number.
        /// </summary>
        [DataMember(Name = nameof(BillingAddress1), EmitDefaultValue = true)]
        public string BillingAddress1 { get; set; }

        /// <summary>
        /// The billing additional address of the company or organization.
        /// </summary>
        [DataMember(Name = nameof(BillingAddress2), EmitDefaultValue = true)]
        public string BillingAddress2 { get; set; }

        /// <summary>
        /// The billing city where the company is located.
        /// </summary>
        [DataMember(Name = nameof(BillingCity), EmitDefaultValue = true)]
        public string BillingCity { get; set; }

        /// <summary>
        /// The billing state or region in which the company or organization is located.
        /// </summary>
        [DataMember(Name = nameof(BillingState), EmitDefaultValue = true)]
        public string BillingState { get; set; }

        /// <summary>
        /// The billing postal or zip code of the company or organization.
        /// </summary>
        [DataMember(Name = nameof(BillingZip), EmitDefaultValue = true)]
        public string BillingZip { get; set; }

        /// <summary>
        /// The billing country/region in which the company or organization is located.
        /// </summary>
        [DataMember(Name = nameof(BillingCountry), EmitDefaultValue = true)]
        public string BillingCountry { get; set; }

        /// <summary>
        /// The main website of the company or organization. This property is used to identify unique companies.
        /// </summary>
        [DataMember(Name = nameof(WebSite), EmitDefaultValue = false)]
        public string WebSite { get; set; }

        /// <summary>
        /// The domain name of the company or organization.
        /// </summary>
        [DataMember(Name = nameof(Domain), EmitDefaultValue = false)]
        public string Domain { get; set; }

        /// <summary>
        /// The total number of employees who work for the company or organization.
        /// </summary>
        [DataMember(Name = nameof(EmployeeCount), EmitDefaultValue = false)]
        public int? EmployeeCount { get; set; }

        /// <summary>
        /// The type of business the company performs. By default, this property has
        /// approximately 150 pre-defined options to select from. While these options
        /// cannot be deleted as they used by HubSpot Insights, you can add new custom
        /// options to meet your needs.
        /// </summary>
        [DataMember(Name = nameof(Industry), EmitDefaultValue = false)]
        public string Industry { get; set; }

        /// <summary>
        /// The actual or estimated annual revenue of the company.
        /// </summary>
        [DataMember(Name = nameof(AnnualRevenue), EmitDefaultValue = false)]
        public decimal? AnnualRevenue { get; set; }

        /// <summary>
        /// The company's sales, prospecting or outreach status.
        /// </summary>
        [DataMember(Name = nameof(LeadStatus), EmitDefaultValue = false)]
        public string LeadStatus { get; set; }

        /// <summary>
        /// The date the company or organization was closed as a customer.
        /// </summary>
        [DataMember(Name = nameof(CloseDate), EmitDefaultValue = false)]
        public DateTime? CloseDate { get; set; }

        [IgnoreDataMember]
        public IEnumerable<HubSpotQuote> Quotes { get; set; }
        [IgnoreDataMember]
        public IEnumerable<HubSpotLineItem> LineItems { get; set; }
        [IgnoreDataMember]
        public IEnumerable<HubSpotContact> Contacts { get; set; }

        [DataMember(Name = nameof(AssociatedQuoteIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedQuoteIds { get; set; }

        [DataMember(Name = nameof(AssociatedLineItemIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedLineItemIds { get; set; }

        [DataMember(Name = nameof(AssociatedContactIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedContactIds { get; set; }

        [DataMember(Name = nameof(AssociatedDealIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedDealIds { get; set; }
    }
}