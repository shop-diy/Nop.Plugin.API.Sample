using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot.Model
{
    public sealed class HubSpotContact : HubSpotEntity
    {
        /// <summary>
        /// Contact's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Contact's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Contact's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Contact's work email.
        /// </summary>
        public string WorkEmail { get; set; }


        /// <summary>
        /// Contact's job title.
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Mobile number in international format.
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Phone number in international format.
        /// </summary>
        public string PhoneNumber { get; set; }

        public IEnumerable<HubSpotCompany> Companies { get; set; }

        internal IEnumerable<string> AssociatedQuoteIds { get; set; }
        internal IEnumerable<string> AssociatedLineItemIds { get; set; }
        internal IEnumerable<string> AssociatedCompanyIds { get; set; }
        internal IEnumerable<string> AssociatedDealIds { get; set; }
    }
}