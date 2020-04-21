using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public partial class HubSpotProperties
    {
        public static class Email
        {
            internal static readonly Dictionary<string, string> _propertyKeyMap = new Dictionary<string, string>
            {
                { nameof(AdditionalEmails), "hs_additional_emails" },
                { nameof(IsEmailInvalid), "hs_email_bad_address" },
                { nameof(EmailDomain), "hs_email_domain" },
                { nameof(EmailHardBounceReason), "hs_email_hard_bounce_reason" },
                { nameof(EmailHardBounceReasonEnum), "hs_email_hard_bounce_reason_enum" },
            };
            /// <summary>
            /// A set of additional email addresses for a contact.
            /// </summary>
            public static string AdditionalEmails => _propertyKeyMap[nameof(AdditionalEmails)];

            /// <summary>
            /// A set of all vids, canonical or otherwise, for a contact.
            /// </summary>
            public static string AllVids => _propertyKeyMap[nameof(AllVids)];

            /// <summary>
            /// Merged vids with timestamps of a contact.
            /// </summary>
            public static string MergedVids => _propertyKeyMap[nameof(MergedVids)];

            /// <summary>
            /// The role that a contact plays during the sales process. Contacts can have more
            /// than one role, and they can share the same role with another contact. Any of
            /// "BLOCKER", "BUDGET_HOLDER", "CHAMPION", "DECISION_MAKER", "END_USER",
            /// "EXECUTIVE_SPONSOR", "INFLUENCER", "LEGAL_AND_COMPLIANCE", "OTHER".
            /// </summary>
            public static string BuyingRole => _propertyKeyMap[nameof(BuyingRole)];

            /// <summary>
            /// A set of all form submissions for a contact.
            /// </summary>
            public static string FormSubmissions => _propertyKeyMap[nameof(FormSubmissions)];

            /// <summary>
            /// Mobile number in international format.
            /// </summary>
            public static string MobileNumber => _propertyKeyMap[nameof(MobileNumber)];

            /// <summary>
            /// Phone number in international format.
            /// </summary>
            public static string PhoneNumber => _propertyKeyMap[nameof(PhoneNumber)];

            /// <summary>
            /// Area Code of the calculated phone number.
            /// </summary>
            public static string AreaCode => _propertyKeyMap[nameof(AreaCode)];

            /// <summary>
            /// Country code of the calculated phone number.
            /// </summary>
            public static string CountryCode => _propertyKeyMap[nameof(CountryCode)];

            /// <summary>
            /// ISO2 Country code for the derived phone number.
            /// </summary>
            public static string RegionCode => _propertyKeyMap[nameof(RegionCode)];

            /// <summary>
            /// Email Confirmation status of user of Content Membership.
            /// </summary>
            public static string IsEmailConfirmed => _propertyKeyMap[nameof(IsEmailConfirmed)];

            /// <summary>
            /// The notes relating to the contact's content membership.
            /// </summary>
            public static string MembershipNotes => _propertyKeyMap[nameof(MembershipNotes)];

            /// <summary>
            /// Datetime at which this user was set up for Content Membership.
            /// </summary>
            public static string RegisteredDate => _propertyKeyMap[nameof(RegisteredDate)];

            /// <summary>
            /// Domain to which the registration invitation email for Content Membership was sent.
            /// </summary>
            public static string RegistrationInvitationEmailDomain => _propertyKeyMap[nameof(RegistrationInvitationEmailDomain)];

            /// <summary>
            /// Datetime at which this user was sent a registration invitation email for Content Membership.
            /// </summary>
            public static string RegistrationInvitationEmailDate => _propertyKeyMap[nameof(RegistrationInvitationEmailDate)];

            /// <summary>
            /// The status of the contact's content membership. One of "active", "inactive".
            /// </summary>
            public static string MembershipStatus => _propertyKeyMap[nameof(MembershipStatus)];

            /// <summary>
            /// A Conversations visitor's email address.
            /// </summary>
            public static string ConversationsVisitorEmail => _propertyKeyMap[nameof(ConversationsVisitorEmail)];

            /// <summary>
            /// Flag indicating this contact was created by the Conversations API.
            /// </summary>
            public static string CreatedByConversations => _propertyKeyMap[nameof(CreatedByConversations)];

            /// <summary>
            /// The last time a shared document (presentation) was accessed by this contact.
            /// </summary>
            public static string LastDocumentRevisitDate => _propertyKeyMap[nameof(LastDocumentRevisitDate)];

            /// <summary>
            /// Indicates if the email address associated with this contact is invalid.
            /// </summary>
            public static string IsEmailInvalid => _propertyKeyMap[nameof(IsEmailInvalid)];

            /// <summary>
            /// A contact's email address domain.
            /// </summary>
            public static string EmailDomain => _propertyKeyMap[nameof(EmailDomain)];

            /// <summary>
            /// The issue that caused a contact to hard bounce from your emails. If this is an error
            /// or a temporary issue, you can unbounce this contact from the contact record.
            /// </summary>
            public static string EmailHardBounceReason => _propertyKeyMap[nameof(EmailHardBounceReason)];

            /// <summary>
            /// The issue that caused a contact to hard bounce from your emails. If this is an error
            /// or a temporary issue, you can unbounce this contact from the contact record. One of
            /// "CONTENT", "MAILBOX_FULL", "OTHER", "POLICY", "SPAM", "UNKNOWN_USER".
            /// </summary>
            public static string EmailHardBounceReasonEnum => _propertyKeyMap[nameof(EmailHardBounceReasonEnum)];

            /// <summary>
            /// Indicates that the current email address has been quarantined for anti-abuse reasons and any marketing email sends to it will be blocked. This is automatically set by HubSpot.
            /// </summary>
            public static string IsEmailQuarantined => _propertyKeyMap[nameof(IsEmailQuarantined)];
        }
    }
}
