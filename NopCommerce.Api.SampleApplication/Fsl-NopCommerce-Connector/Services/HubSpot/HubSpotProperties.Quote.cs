using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public partial class HubSpotProperties
    {
        public static class Quote
        {
            internal static readonly Dictionary<string, string> _propertyKeyMap = new Dictionary<string, string>
            {
                { nameof(ApproverId), "hs_approver_id" },
                { nameof(DiscountDisplayStyle), "hs_discount_display_style" },
                { nameof(ESignDate), "hs_esign_date" },
                { nameof(Feedback), "hs_feedback" },
                { nameof(Language), "hs_language" },
                { nameof(Locale), "hs_locale" },
                { nameof(Locked), "hs_locked" },
                { nameof(PaymentDate), "hs_payment_date" },
                { nameof(PdfDownloadLink), "hs_pdf_download_link" },
                { nameof(PublicUrlKey), "hs_public_url_key" },
                { nameof(SenderCompanyName), "hs_sender_company_name" },
                { nameof(SenderFirstName), "hs_sender_firstname" },
                { nameof(Title), "hs_title" },
                { nameof(ExpirationDate), "hs_expiration_date" },
                { nameof(SenderCompanyDomain), "hs_sender_company_domain" },
                { nameof(SenderLastName), "hs_sender_lastname" },
                { nameof(Comments), "hs_comments" },
                { nameof(SenderCompanyAddress1), "hs_sender_company_address" },
                { nameof(SenderCompanyAddress2), "hs_sender_company_address2" },
                { nameof(SenderEmail), "hs_sender_email" },
                { nameof(SenderPhone), "hs_sender_phone" },
                { nameof(Terms), "hs_terms" },
                { nameof(LogoUrl), "hs_logo_url" },
                { nameof(SenderCompanyCity), "hs_sender_company_city" },
                { nameof(SenderJobTitle), "hs_sender_jobtitle" },
                { nameof(SenderCompanyState), "hs_sender_company_state" },
                { nameof(SenderCompanyCountry), "hs_sender_company_country" },
                { nameof(SenderCompanyImageUrl), "hs_sender_company_image_url" },
                { nameof(SignatureRequired), "hs_show_signature_box" },
                { nameof(PrimaryColor), "hs_primary_color" },
                { nameof(SenderCompanyZip), "hs_sender_company_zip" },
                { nameof(Currency), "hs_currency" },
                { nameof(PaymentEnabled), "hs_payment_enabled" },
                { nameof(ESignEnabled), "hs_esign_enabled" },
                { nameof(ESignSignaturesRequired), "hs_esign_num_signers_required" },
                { nameof(ESignSignaturesCompleted), "hs_esign_num_signers_completed" },
                { nameof(Template), "hs_template" },
                { nameof(Amount), "hs_quote_amount" },
                { nameof(ApprovalStatus), "hs_status" },
                { nameof(QuoteNumber), "hs_quote_number" },
                { nameof(CollectShippingAddress), "hs_collect_shipping_address" },
            };

            /// <summary>
            /// The ID of the user that can approve this quote.
            /// </summary>
            public static string ApproverId => _propertyKeyMap[nameof(ApproverId)];

            /// <summary>
            /// The display style of line item discounts. One of "fixed", "percentage".
            /// </summary>
            public static string DiscountDisplayStyle => _propertyKeyMap[nameof(DiscountDisplayStyle)];

            /// <summary>
            /// The date and time the document was signed by all signers.
            /// </summary>
            public static string ESignDate => _propertyKeyMap[nameof(ESignDate)];

            /// <summary>
            /// Feedback about this quote during the approval process.
            /// </summary>
            public static string Feedback => _propertyKeyMap[nameof(Feedback)];

            /// <summary>
            /// The language for displaying this quote publicly.
            /// </summary>
            public static string Language => _propertyKeyMap[nameof(Language)];

            /// <summary>
            /// The locale for displaying this quote publicly.
            /// </summary>
            public static string Locale => _propertyKeyMap[nameof(Locale)];

            /// <summary>
            /// Indicates if this quote is locked and can never be updated.
            /// </summary>
            public static string Locked => _propertyKeyMap[nameof(Locked)];

            /// <summary>
            /// The date the quote was paid by the customer.
            /// </summary>
            public static string PaymentDate => _propertyKeyMap[nameof(PaymentDate)];

            /// <summary>
            /// The link to download a pdf of the quote.
            /// </summary>
            public static string PdfDownloadLink => _propertyKeyMap[nameof(PdfDownloadLink)];

            /// <summary>
            /// Key for accessing quote document URL.
            /// </summary>
            public static string PublicUrlKey => _propertyKeyMap[nameof(PublicUrlKey)];

            /// <summary>
            /// The name of the company sending this quote.
            /// </summary>
            public static string SenderCompanyName => _propertyKeyMap[nameof(SenderCompanyName)];

            /// <summary>
            /// The street address of the company sending this quote.
            /// </summary>
            public static string SenderCompanyAddress1 => _propertyKeyMap[nameof(SenderCompanyAddress1)];

            /// <summary>
            /// The second line of the street address of the company sending this quote.
            /// </summary>
            public static string SenderCompanyAddress2 => _propertyKeyMap[nameof(SenderCompanyAddress2)];

            /// <summary>
            /// The city in which the company sending this quote is located.
            /// </summary>
            public static string SenderCompanyCity => _propertyKeyMap[nameof(SenderCompanyCity)];

            /// <summary>
            /// The state/region in which the company sending this quote is located.
            /// </summary>
            public static string SenderCompanyState => _propertyKeyMap[nameof(SenderCompanyState)];

            /// <summary>
            /// The zip code in which the company sending this quote is located.
            /// </summary>
            public static string SenderCompanyZip => _propertyKeyMap[nameof(SenderCompanyZip)];

            /// <summary>
            /// The country in which the company sending this quote is located.
            /// </summary>
            public static string SenderCompanyCountry => _propertyKeyMap[nameof(SenderCompanyCountry)];

            /// <summary>
            /// URL to image of the sender company image to be set on the quote.
            /// </summary>
            public static string SenderCompanyImageUrl => _propertyKeyMap[nameof(SenderCompanyImageUrl)];

            /// <summary>
            /// The domain of the company sending this quote.
            /// </summary>
            public static string SenderCompanyDomain => _propertyKeyMap[nameof(SenderCompanyDomain)];

            /// <summary>
            /// First name of the sender of this quote.
            /// </summary>
            public static string SenderFirstName => _propertyKeyMap[nameof(SenderFirstName)];

            /// <summary>
            /// Last name of the sender of this quote.
            /// </summary>
            public static string SenderLastName => _propertyKeyMap[nameof(SenderLastName)];

            /// <summary>
            /// Email address of the sender of this quote.
            /// </summary>
            public static string SenderEmail => _propertyKeyMap[nameof(SenderEmail)];

            /// <summary>
            /// Phone number of the sender of this quote.
            /// </summary>
            public static string SenderPhone => _propertyKeyMap[nameof(SenderPhone)];

            /// <summary>
            /// Job title of the sender of this quote.
            /// </summary>
            public static string SenderJobTitle => _propertyKeyMap[nameof(SenderJobTitle)];

            /// <summary>
            /// The title of this quote.
            /// </summary>
            public static string Title => _propertyKeyMap[nameof(Title)];

            /// <summary>
            /// The date that this quote expires.
            /// </summary>
            public static string ExpirationDate => _propertyKeyMap[nameof(ExpirationDate)];

            /// <summary>
            /// Comments to the buyer.
            /// </summary>
            public static string Comments => _propertyKeyMap[nameof(Comments)];

            /// <summary>
            /// Any relevant information about pricing, purchasing terms, and/or master agreements.
            /// </summary>
            public static string Terms => _propertyKeyMap[nameof(Terms)];

            /// <summary>
            /// URL to image of the logo displayed on the quote.
            /// </summary>
            public static string LogoUrl => _propertyKeyMap[nameof(LogoUrl)];

            /// <summary>
            /// Indicates if the quote document should have a place for a written signature.
            /// </summary>
            public static string SignatureRequired => _propertyKeyMap[nameof(SignatureRequired)];

            /// <summary>
            /// Color value used on the quote document.
            /// </summary>
            public static string PrimaryColor => _propertyKeyMap[nameof(PrimaryColor)];

            /// <summary>
            /// Currency code for the quote.
            /// </summary>
            public static string Currency => _propertyKeyMap[nameof(Currency)];

            /// <summary>
            /// Indicates if payment can be collected via the quote link.
            /// </summary>
            public static string PaymentEnabled => _propertyKeyMap[nameof(PaymentEnabled)];

            /// <summary>
            /// Indicates if esign is enabled for quote.
            /// </summary>
            public static string ESignEnabled => _propertyKeyMap[nameof(ESignEnabled)];

            /// <summary>
            /// Total number of signers required for this quote to be fully signed.
            /// </summary>
            public static string ESignSignaturesRequired => _propertyKeyMap[nameof(ESignSignaturesRequired)];

            /// <summary>
            /// Number of completed signatures collected so far.
            /// </summary>
            public static string ESignSignaturesCompleted => _propertyKeyMap[nameof(ESignSignaturesCompleted)];

            /// <summary>
            /// Customize how your quote should look and feel. One of "ORIGINAL", "BASIC", "MODERN".
            /// </summary>
            public static string Template => _propertyKeyMap[nameof(Template)];

            /// <summary>
            /// The total due for the quote.
            /// </summary>
            public static string Amount => _propertyKeyMap[nameof(Amount)];

            /// <summary>
            /// Approval status of the quote. One of "DRAFT", "PENDING_APPROVAL", "REJECTED", "APPROVED", "APPROVAL_NOT_NEEDED".
            /// </summary>
            public static string ApprovalStatus => _propertyKeyMap[nameof(ApprovalStatus)];

            /// <summary>
            /// Reference number shown on quote document.
            /// </summary>
            public static string QuoteNumber => _propertyKeyMap[nameof(QuoteNumber)];

            /// <summary>
            /// Indicates if shipping address should be collected with this quote.
            /// </summary>
            public static string CollectShippingAddress => _propertyKeyMap[nameof(CollectShippingAddress)];
        }
    }
}
