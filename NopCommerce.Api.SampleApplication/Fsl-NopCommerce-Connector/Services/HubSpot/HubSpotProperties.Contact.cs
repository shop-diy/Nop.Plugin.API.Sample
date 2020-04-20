using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public partial class HubSpotProperties
    {
        public static class Contact
        {
            internal static readonly Dictionary<string, string> _propertyKeyMap = new Dictionary<string, string>
            {
                { nameof(CompanySize), "company_size" },
                { nameof(DateOfBirth), "date_of_birth" },
                { nameof(DaysToClose), "days_to_close" },
                { nameof(Degree), "degree" },
                { nameof(FieldOfStudy), "field_of_study" },
                { nameof(FirstConversionDate), "first_conversion_date" },
                { nameof(FirstConversion), "first_conversion_event_name" },
                { nameof(FirstDealCreateDate), "first_deal_created_date" },
                { nameof(Gender), "gender" },
                { nameof(GraduationDate), "graduation_date" },
                { nameof(AdditionalEmails), "hs_additional_emails" },
                { nameof(AllVids), "hs_all_contact_vids" },
                { nameof(MergedVids), "hs_calculated_merged_vids" },
                { nameof(BuyingRole), "hs_buying_role" },
                { nameof(FormSubmissions), "hs_calculated_form_submissions" },
                { nameof(MobileNumber), "hs_calculated_mobile_number" },
                { nameof(PhoneNumber), "hs_calculated_phone_number" },
                { nameof(AreaCode), "hs_calculated_phone_number_area_code" },
                { nameof(CountryCode), "hs_calculated_phone_number_country_code" },
                { nameof(RegionCode), "hs_calculated_phone_number_region_code" },
                { nameof(IsEmailConfirmed), "hs_content_membership_email_confirmed" },
                { nameof(MembershipNotes), "hs_content_membership_notes" },
                { nameof(RegisteredDate), "hs_content_membership_registered_at" },
                { nameof(RegistrationInvitationEmailDomain), "hs_content_membership_registration_domain_sent_to" },
                { nameof(RegistrationInvitationEmailDate), "hs_content_membership_registration_email_sent_at" },
                { nameof(MembershipStatus), "hs_content_membership_status" },
                { nameof(ConversationsVisitorEmail), "hs_conversations_visitor_email" },
                { nameof(CreatedByConversations), "hs_created_by_conversations" },
                { nameof(LastDocumentRevisitDate), "hs_document_last_revisited" },
                { nameof(IsEmailInvalid), "hs_email_bad_address" },
                { nameof(EmailDomain), "hs_email_domain" },
                { nameof(EmailHardBounceReason), "hs_email_hard_bounce_reason" },
                { nameof(EmailHardBounceReasonEnum), "hs_email_hard_bounce_reason_enum" },
                { nameof(Email), "email" },
                { nameof(WorkEmail), "work_email" },
                { nameof(FirstName), "firstname" },
                { nameof(LastName), "lastname" },
                { nameof(JobTitle), "jobtitle" },
            };

            /// <summary>
            /// A contact's company size. This property is required for the Facebook Ads Integration.
            /// This property will be automatically synced via the Lead Ads tool.
            /// </summary>
            public static string CompanySize => _propertyKeyMap[nameof(CompanySize)];

            /// <summary>
            /// A contact's date of birth. This property is required for the Facebook Ads Integration.
            /// This property will be automatically synced via the Lead Ads tool.
            /// </summary>
            public static string DateOfBirth => _propertyKeyMap[nameof(DateOfBirth)];

            /// <summary>
            /// The days that elapsed from when a contact was created until they closed as a customer.
            /// This is set automatically by HubSpot and can be used for segmentation and reporting.
            /// </summary>
            public static string DaysToClose => _propertyKeyMap[nameof(DaysToClose)];

            /// <summary>
            /// A contact's degree. This property is required for the Facebook Ads Integration.
            /// This property will be automatically synced to via Lead Ads tool.
            /// </summary>
            public static string Degree => _propertyKeyMap[nameof(Degree)];

            /// <summary>
            /// A contact's field of study. This property is required for the Facebook Ads Integration.
            /// This property will be automatically synced via the Lead Ads tool
            /// </summary>
            public static string FieldOfStudy => _propertyKeyMap[nameof(FieldOfStudy)];

            /// <summary>
            /// The date this contact first submitted a form.
            /// </summary>
            public static string FirstConversionDate => _propertyKeyMap[nameof(FirstConversionDate)];

            /// <summary>
            /// The first form this contact submitted.
            /// </summary>
            public static string FirstConversion => _propertyKeyMap[nameof(FirstConversion)];

            /// <summary>
            /// The date the first deal for a contact was created. This is automatically set by
            /// HubSpot and can be used for segmentation and reporting.
            /// </summary>
            public static string FirstDealCreateDate => _propertyKeyMap[nameof(FirstDealCreateDate)];

            /// <summary>
            /// A contact's gender.
            /// </summary>
            public static string Gender => _propertyKeyMap[nameof(Gender)];

            /// <summary>
            /// "A contact's graduation date. This property is required for the Facebook Ads Integration.
            /// This property will be automatically synced via the Lead Ads tool.
            /// </summary>
            public static string GraduationDate => _propertyKeyMap[nameof(GraduationDate)];

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

            /// <summary>
            /// Contact's email address.
            /// </summary>
            public static string Email => _propertyKeyMap[nameof(Email)];

            /// <summary>
            /// Contact's work email.
            /// </summary>
            public static string WorkEmail => _propertyKeyMap[nameof(WorkEmail)];

            /// <summary>
            /// Contact's first name.
            /// </summary>
            public static string FirstName => _propertyKeyMap[nameof(FirstName)];

            /// <summary>
            /// Contact's last name.
            /// </summary>
            public static string LastName => _propertyKeyMap[nameof(LastName)];

            /// <summary>
            /// Contact's job title.
            /// </summary>
            public static string JobTitle => _propertyKeyMap[nameof(JobTitle)];
        }
    }
}
