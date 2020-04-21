using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Model.HubSpot
{
    [DataContract]
    public sealed class HubSpotContact : HubSpotEntity
    {
        /// <summary>
        /// Contact's first name.
        /// </summary>
        [DataMember(Name = nameof(FirstName), EmitDefaultValue = false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Contact's last name.
        /// </summary>
        [DataMember(Name = nameof(LastName), EmitDefaultValue = false)]
        public string LastName { get; set; }

        /// <summary>
        /// Contact's email address.
        /// </summary>
        [DataMember(Name = nameof(Email), EmitDefaultValue = true)]
        public string Email { get; set; }

        /// <summary>
        /// Contact's work email.
        /// </summary>
        [DataMember(Name = nameof(WorkEmail), EmitDefaultValue = false)]
        public string WorkEmail { get; set; }


        /// <summary>
        /// Contact's job title.
        /// </summary>
        [DataMember(Name = nameof(JobTitle), EmitDefaultValue = false)]
        public string JobTitle { get; set; }

        /// <summary>
        /// Mobile number in international format.
        /// </summary>
        [DataMember(Name = nameof(MobileNumber), EmitDefaultValue = false)]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Phone number in international format.
        /// </summary>
        [DataMember(Name = nameof(PhoneNumber), EmitDefaultValue = false)]
        public string PhoneNumber { get; set; }

        [IgnoreDataMember]
        public IEnumerable<HubSpotCompany> Companies { get; set; }

        [DataMember(Name = nameof(AssociatedQuoteIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedQuoteIds { get; set; }

        [DataMember(Name = nameof(AssociatedLineItemIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedLineItemIds { get; set; }

        [DataMember(Name = nameof(AssociatedCompanyIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedCompanyIds { get; set; }

        [DataMember(Name = nameof(AssociatedDealIds), EmitDefaultValue = false)]
        public IEnumerable<string> AssociatedDealIds { get; set; }
    }
}