using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public partial class HubSpotProperties
    {
        public static class Company
        {
            internal static readonly Dictionary<string, string> _propertyKeyMap = new Dictionary<string, string>
            {
                { nameof(AboutUs), "about_us" },
                { nameof(FacebookCompanyPage), "facebook_company_page" },
                { nameof(FacebookFans), "facebookfans" },
                { nameof(FirstConversionDate), "first_conversion_date" },
                { nameof(FirstConversionEvent), "first_conversion_event_name" },
                { nameof(FirstDealCreateDate), "first_deal_created_date" },
                { nameof(YearFounded), "founded_year" },
                { nameof(AdditionalDomains), "hs_additional_domains" },
                { nameof(AvatarKey), "hs_avatar_filemanager_key" },
                { nameof(IdealCustomerProfileTier), "hs_ideal_customer_profile" },
                { nameof(IsTargetAccount), "hs_is_target_account" },
                { nameof(LastBookedMeetingDate), "hs_last_booked_meeting_date" },
                { nameof(LastLoggedCallDate), "hs_last_logged_call_date" },
                { nameof(LastOpenTaskDate), "hs_last_open_task_date" },
                { nameof(LastSalesActivityDate), "hs_last_sales_activity_date" },
                { nameof(BlockerCount), "hs_num_blockers" },
                { nameof(DecisionMakerCount), "hs_num_decision_makers" },
                { nameof(OpenDealCount), "hs_num_open_deals" },
                { nameof(PredictiveContactScoreV2), "hs_predictivecontactscore_v2" },
                { nameof(TargetAccount), "hs_target_account" },
                { nameof(TargetAccountProbability), "hs_target_account_probability" },
                { nameof(TotalDealValue), "hs_total_deal_value" },
                { nameof(IsPublic), "is_public" },
                { nameof(AssociatedContactCount), "num_associated_contacts" },
                { nameof(ConversionCount), "num_conversion_events" },
                { nameof(RecentConversionDate), "recent_conversion_date" },
                { nameof(RecentConversion), "recent_conversion_event_name" },
                { nameof(RecentDealAmount), "recent_deal_amount" },
                { nameof(RecentDealCloseDate), "recent_deal_close_date" },
                { nameof(TimeZone), "timezone" },
                { nameof(TotalMoneyRaised), "total_money_raised" },
                { nameof(TotalRevenue), "total_revenue" },
                { nameof(Name), "name" },
                { nameof(OwnerEmail), "owneremail" },
                { nameof(TwitterHandle), "twitterhandle" },
                { nameof(TwitterBio), "twitterbio" },
                { nameof(TwitterFollowers), "twitterfollowers" },
                { nameof(LinkedInCompanyPage), "linkedin_company_page" },
                { nameof(LinkedInBio), "linkedinbio" },
                { nameof(OwnerName), "ownername" },
                { nameof(Phone), "phone" },
                { nameof(Address1), "address" },
                { nameof(Address2), "address2" },
                { nameof(City), "city" },
                { nameof(State), "state" },
                { nameof(Zip), "zip" },
                { nameof(Country), "country" },
                { nameof(LastMeetingBookedDate), "engagements_last_meeting_booked" },
                { nameof(LastMeetingBookedCampaign), "engagements_last_meeting_booked_campaign" },
                { nameof(LastMeetingBookedMedium), "engagements_last_meeting_booked_medium" },
                { nameof(LastMeetingBookedSource), "engagements_last_meeting_booked_source" },
                { nameof(LastMeetingActivityDate), "hs_latest_meeting_activity" },
                { nameof(LastSalesEmailRepliedDate), "hs_sales_email_last_replied" },
                { nameof(Website), "website" },
                { nameof(Domain), "domain" },
                { nameof(EmployeeCount), "numberofemployees" },
                { nameof(Industry), "industry" },
                { nameof(AnnualRevenue), "annualrevenue" },
                { nameof(LifecycleStage), "lifecyclestage" },
                { nameof(LeadStatus), "hs_lead_status" },
                { nameof(ParentCompanyId), "hs_parent_company_id" },
                { nameof(Type), "type" },
                { nameof(Description), "description" },
                { nameof(ChildCompanyCount), "description" },
                { nameof(HubSpotScore), "hubspotscore" },
                { nameof(CreateDate), "createdate" },
                { nameof(CloseDate), "closedate" },
                { nameof(FirstContactCreateDate), "first_contact_createdate" },
                { nameof(DaysToClose), "days_to_close" },
                { nameof(WebTechnologies), "web_technologies" },
            };

            /// <summary>
            /// The ID of the user that can approve this quote.
            /// </summary>
            public static string AboutUs => _propertyKeyMap[nameof(AboutUs)];

            /// <summary>
            /// The URL of the Facebook company page for the company or organization.
            /// </summary>
            public static string FacebookCompanyPage => _propertyKeyMap[nameof(FacebookCompanyPage)];

            /// <summary>
            /// Number of facebook fans.
            /// </summary>
            public static string FacebookFans => _propertyKeyMap[nameof(FacebookFans)];

            /// <summary>
            /// The first conversion date across all contacts associated this company or organization.
            /// </summary>
            public static string FirstConversionDate => _propertyKeyMap[nameof(FirstConversionDate)];

            /// <summary>
            /// The first form submitted across all contacts associated this company or organization.
            /// </summary>
            public static string FirstConversionEvent => _propertyKeyMap[nameof(FirstConversionEvent)];

            /// <summary>
            /// The create date of the first deal associated with this company.
            /// </summary>
            public static string FirstDealCreateDate => _propertyKeyMap[nameof(FirstDealCreateDate)];

            /// <summary>
            /// The year the company was created.
            /// </summary>
            public static string YearFounded => _propertyKeyMap[nameof(YearFounded)];

            /// <summary>
            /// Additional domains belonging to this company.
            /// </summary>
            public static string AdditionalDomains => _propertyKeyMap[nameof(AdditionalDomains)];

            /// <summary>
            /// The path in the FileManager CDN for this company's avatar override image.
            /// </summary>
            public static string AvatarKey => _propertyKeyMap[nameof(AvatarKey)];

            /// <summary>
            /// This property shows how well a Company matches your Ideal Customer Profile.
            /// Companies that are Tier 1 should be a great fit for your products/services
            /// where Tier 3 might be acceptable, but low priority. One of "tier_1", "tier_2",
            /// "tier_3".
            /// </summary>
            public static string IdealCustomerProfileTier => _propertyKeyMap[nameof(IdealCustomerProfileTier)];

            /// <summary>
            /// The Target Account property identifies the companies that you are marketing and selling to as part of your account-based strategy.
            /// </summary>
            public static string IsTargetAccount => _propertyKeyMap[nameof(IsTargetAccount)];

            /// <summary>
            /// The last date of booked meetings associated with the company.
            /// </summary>
            public static string LastBookedMeetingDate => _propertyKeyMap[nameof(LastBookedMeetingDate)];

            /// <summary>
            /// The last date of logged calls associated with the company.
            /// </summary>
            public static string LastLoggedCallDate => _propertyKeyMap[nameof(LastLoggedCallDate)];

            /// <summary>
            /// The last due date of open tasks associated with the company.
            /// </summary>
            public static string LastOpenTaskDate => _propertyKeyMap[nameof(LastOpenTaskDate)];

            /// <summary>
            /// The date of the last sales activity with the company.
            /// </summary>
            public static string LastSalesActivityDate => _propertyKeyMap[nameof(LastSalesActivityDate)];

            /// <summary>
            /// The number of contacts associated with this company with the role of blocker.
            /// </summary>
            public static string BlockerCount => _propertyKeyMap[nameof(BlockerCount)];

            /// <summary>
            /// The number of contacts associated with this company with the role of decision maker.
            /// </summary>
            public static string DecisionMakerCount => _propertyKeyMap[nameof(DecisionMakerCount)];

            /// <summary>
            /// The number of open deals associated with this company.
            /// </summary>
            public static string OpenDealCount => _propertyKeyMap[nameof(OpenDealCount)];

            /// <summary>
            /// The highest probability that a contact associated with this company will become a customer within the next 90 days.
            /// This score is based on standard contact properties and behavior.
            /// </summary>
            public static string PredictiveContactScoreV2 => _propertyKeyMap[nameof(PredictiveContactScoreV2)];

            /// <summary>
            /// The Target Account property is a means to flag high priority companies if you are
            /// following an account based strategy. One of "tier_1", "tier_2", "tier_3".
            /// </summary>
            public static string TargetAccount => _propertyKeyMap[nameof(TargetAccount)];

            /// <summary>
            /// The probability a company is marked as a target account.
            /// </summary>
            public static string TargetAccountProbability => _propertyKeyMap[nameof(TargetAccountProbability)];

            /// <summary>
            /// The total value, in your company's currency, of all open deals associated with this company.
            /// </summary>
            public static string TotalDealValue => _propertyKeyMap[nameof(TotalDealValue)];

            /// <summary>
            /// Indicates whether or not the company is publicly traded.
            /// </summary>
            public static string IsPublic => _propertyKeyMap[nameof(IsPublic)];

            /// <summary>
            /// The number of contacts associated with this company.
            /// </summary>
            public static string AssociatedContactCount => _propertyKeyMap[nameof(AssociatedContactCount)];

            /// <summary>
            /// The number of forms submission for all contacts associated with this company or organization.
            /// </summary>
            public static string ConversionCount => _propertyKeyMap[nameof(ConversionCount)];

            /// <summary>
            /// The most recent conversion date across all contacts associated this company or organization.
            /// </summary>
            public static string RecentConversionDate => _propertyKeyMap[nameof(RecentConversionDate)];

            /// <summary>
            /// The last form submitted across all contacts associated this company or organization.
            /// </summary>
            public static string RecentConversion => _propertyKeyMap[nameof(RecentConversion)];

            /// <summary>
            /// The amount of the last deal closed.
            /// </summary>
            public static string RecentDealAmount => _propertyKeyMap[nameof(RecentDealAmount)];

            /// <summary>
            /// The date of the last `closed won` deal associated with this company record.
            /// </summary>
            public static string RecentDealCloseDate => _propertyKeyMap[nameof(RecentDealCloseDate)];

            /// <summary>
            /// The time zone where the company or organization is located.
            /// </summary>
            public static string TimeZone => _propertyKeyMap[nameof(TimeZone)];

            /// <summary>
            /// The total amount of money raised by the company.
            /// </summary>
            public static string TotalMoneyRaised => _propertyKeyMap[nameof(TotalMoneyRaised)];

            /// <summary>
            /// The total amount of closed won deals.
            /// </summary>
            public static string TotalRevenue => _propertyKeyMap[nameof(TotalRevenue)];

            /// <summary>
            /// The name of the company or organization.
            /// </summary>
            public static string Name => _propertyKeyMap[nameof(Name)];

            /// <summary>
            /// HubSpot owner email for this company or organization.
            /// </summary>
            public static string OwnerEmail => _propertyKeyMap[nameof(OwnerEmail)];

            /// <summary>
            /// The main twitter account of the company or organization.
            /// </summary>
            public static string TwitterHandle => _propertyKeyMap[nameof(TwitterHandle)];

            /// <summary>
            /// The Twitter bio of the company or organization.
            /// </summary>
            public static string TwitterBio => _propertyKeyMap[nameof(TwitterBio)];

            /// <summary>
            /// The number of Twitter followers of the company or organization.
            /// </summary>
            public static string TwitterFollowers => _propertyKeyMap[nameof(TwitterFollowers)];

            /// <summary>
            /// The URL of the LinkedIn company page for the company or organization.
            /// </summary>
            public static string LinkedInCompanyPage => _propertyKeyMap[nameof(LinkedInCompanyPage)];

            /// <summary>
            /// The LinkedIn bio for the company or organization.
            /// </summary>
            public static string LinkedInBio => _propertyKeyMap[nameof(LinkedInBio)];

            /// <summary>
            /// "HubSpot owner name for this company or organization.
            /// </summary>
            public static string OwnerName => _propertyKeyMap[nameof(OwnerName)];

            /// <summary>
            /// A company's primary phone number.
            /// </summary>
            public static string Phone => _propertyKeyMap[nameof(Phone)];

            /// <summary>
            /// The street address of the company or organization, including unit number.
            /// </summary>
            public static string Address1 => _propertyKeyMap[nameof(Address1)];

            /// <summary>
            /// The additional address of the company or organization.
            /// </summary>
            public static string Address2 => _propertyKeyMap[nameof(Address2)];

            /// <summary>
            /// The city where the company is located.
            /// </summary>
            public static string City => _propertyKeyMap[nameof(City)];

            /// <summary>
            /// The state or region in which the company or organization is located.
            /// </summary>
            public static string State => _propertyKeyMap[nameof(State)];

            /// <summary>
            /// The postal or zip code of the company or organization.
            /// </summary>
            public static string Zip => _propertyKeyMap[nameof(Zip)];

            /// <summary>
            /// The country/region in which the company or organization is located.
            /// </summary>
            public static string Country => _propertyKeyMap[nameof(Country)];

            /// <summary>
            /// The date of the most recent meeting an associated contact has booked through the meetings tool.
            /// </summary>
            public static string LastMeetingBookedDate => _propertyKeyMap[nameof(LastMeetingBookedDate)];

            /// <summary>
            /// This UTM parameter shows which marketing campaign (e.g. a specific email) referred an
            /// associated contact to the meetings tool for their most recent booking. This property is
            /// only populated when you add tracking parameters to your meeting link.
            /// </summary>
            public static string LastMeetingBookedCampaign => _propertyKeyMap[nameof(LastMeetingBookedCampaign)];

            /// <summary>
            /// This UTM parameter shows which channel (e.g. email) referred an associated contact to the
            /// meetings tool for their most recent booking. This property is only populated when you add
            /// tracking parameters to your meeting link.
            /// </summary>
            public static string LastMeetingBookedMedium => _propertyKeyMap[nameof(LastMeetingBookedMedium)];

            /// <summary>
            /// This UTM parameter shows which site (e.g. Twitter) referred an associated contact to the
            /// meetings tool for their most recent booking. This property is only populated when you add
            /// tracking parameters to your meeting link.
            /// </summary>
            public static string LastMeetingBookedSource => _propertyKeyMap[nameof(LastMeetingBookedSource)];

            /// <summary>
            /// The date of the most recent meeting (past or upcoming) logged for, scheduled with, or booked by a contact associated with this company.
            /// </summary>
            public static string LastMeetingActivityDate => _propertyKeyMap[nameof(LastMeetingActivityDate)];

            /// <summary>
            /// The last time a tracked sales email was replied to by this company.
            /// </summary>
            public static string LastSalesEmailRepliedDate => _propertyKeyMap[nameof(LastSalesEmailRepliedDate)];

            /// <summary>
            /// The main website of the company or organization. This property is used to identify unique companies.
            /// </summary>
            public static string Website => _propertyKeyMap[nameof(Website)];

            /// <summary>
            /// The domain name of the company or organization.
            /// </summary>
            public static string Domain => _propertyKeyMap[nameof(Domain)];

            /// <summary>
            /// The total number of employees who work for the company or organization.
            /// </summary>
            public static string EmployeeCount => _propertyKeyMap[nameof(EmployeeCount)];

            /// <summary>
            /// The type of business the company performs. By default, this property has
            /// approximately 150 pre-defined options to select from. While these options
            /// cannot be deleted as they used by HubSpot Insights, you can add new custom
            /// options to meet your needs.
            /// </summary>
            public static string Industry => _propertyKeyMap[nameof(Industry)];

            /// <summary>
            /// The actual or estimated annual revenue of the company.
            /// </summary>
            public static string AnnualRevenue => _propertyKeyMap[nameof(AnnualRevenue)];

            /// <summary>
            /// The most advanced lifecycle stage across all contacts associated with this company or organization.
            /// </summary>
            public static string LifecycleStage => _propertyKeyMap[nameof(LifecycleStage)];

            /// <summary>
            /// The company's sales, prospecting or outreach status.
            /// </summary>
            public static string LeadStatus => _propertyKeyMap[nameof(LeadStatus)];

            /// <summary>
            /// The parent company of this company.
            /// </summary>
            public static string ParentCompanyId => _propertyKeyMap[nameof(ParentCompanyId)];

            /// <summary>
            /// The optional classification of this company record - prospect, partner, etc.
            /// One of "PROSPECT", "PARTNER", "RESELLER", "VENDOR", "OTHER".
            /// </summary>
            public static string Type => _propertyKeyMap[nameof(Type)];

            /// <summary>
            /// A short statement about the company's mission and goals.
            /// </summary>
            public static string Description => _propertyKeyMap[nameof(Description)];

            /// <summary>
            /// The number of child companies of this company.
            /// </summary>
            public static string ChildCompanyCount => _propertyKeyMap[nameof(ChildCompanyCount)];

            /// <summary>
            /// The sales and marketing score for the company or organization.
            /// </summary>
            public static string HubSpotScore => _propertyKeyMap[nameof(HubSpotScore)];

            /// <summary>
            /// The date the company or organization was added to the database.
            /// </summary>
            public static string CreateDate => _propertyKeyMap[nameof(CreateDate)];

            /// <summary>
            /// The date the company or organization was closed as a customer.
            /// </summary>
            public static string CloseDate => _propertyKeyMap[nameof(CloseDate)];

            /// <summary>
            /// The date that the first contact from this company entered the system, which could pre-date the company's create date.
            /// </summary>
            public static string FirstContactCreateDate => _propertyKeyMap[nameof(FirstContactCreateDate)];

            /// <summary>
            /// The number of days between when the company record was created and when they closed as a customer.
            /// </summary>
            public static string DaysToClose => _propertyKeyMap[nameof(DaysToClose)];

            /// <summary>
            /// The web technologies used by the company or organization.
            /// </summary>
            public static string WebTechnologies => _propertyKeyMap[nameof(WebTechnologies)];
        }
    }
}
