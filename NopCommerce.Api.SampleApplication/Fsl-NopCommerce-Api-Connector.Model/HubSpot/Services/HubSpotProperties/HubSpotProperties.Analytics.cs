using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public partial class HubSpotProperties
    {
        public static class Analytics
        {
            internal static readonly Dictionary<string, string> _propertyKeyMap = new Dictionary<string, string>
            {
                { nameof(FirstActivityDate), "hs_analytics_first_timestamp" },
                { nameof(FirstTouchConvertingCampaign), "hs_analytics_first_touch_converting_campaign" },
                { nameof(LastTouchConvertingCampaign), "hs_analytics_last_touch_converting_campaign" },
                { nameof(FirstVisitDate), "hs_analytics_first_visit_timestamp" },
                { nameof(LastVisitDate), "hs_analytics_last_visit_timestamp" },
                { nameof(LastSeenDate), "hs_analytics_last_timestamp" },
                { nameof(PageViewCount), "hs_analytics_num_page_views" },
                { nameof(SessionCount), "hs_analytics_num_visits" },
                { nameof(OriginalSourceType), "hs_analytics_source" },
                { nameof(OriginalSourceData1), "hs_analytics_source_data_1" },
                { nameof(OriginalSourceData2), "hs_analytics_source_data_2" },
            };

            /// <summary>
            /// The first activity for any contact associated with this company or organization.
            /// </summary>
            public static string FirstActivityDate => _propertyKeyMap[nameof(FirstActivityDate)];

            /// <summary>
            /// The campaign responsible for the first touch creation of the first contact associated with this company.
            /// </summary>
            public static string FirstTouchConvertingCampaign => _propertyKeyMap[nameof(FirstTouchConvertingCampaign)];

            /// <summary>
            /// The campaign responsible for the last touch creation of the first contact associated with this company.
            /// </summary>
            public static string LastTouchConvertingCampaign => _propertyKeyMap[nameof(LastTouchConvertingCampaign)];

            /// <summary>
            /// Time of first session across all contacts associated with this company or organization.
            /// </summary>
            public static string FirstVisitDate => _propertyKeyMap[nameof(FirstVisitDate)];

            /// <summary>
            /// Time of the last session attributed to any contacts that are associated with this company.
            /// </summary>
            public static string LastVisitDate => _propertyKeyMap[nameof(LastVisitDate)];

            /// <summary>
            /// Time last seen across all contacts associated with this company or organization.
            /// </summary>
            public static string LastSeenDate => _propertyKeyMap[nameof(LastSeenDate)];

            /// <summary>
            /// Total number of page views across all contacts associated with this company or organization.
            /// </summary>
            public static string PageViewCount => _propertyKeyMap[nameof(PageViewCount)];

            /// <summary>
            /// Total number of sessions across all contacts associated with this company or organization.
            /// </summary>
            public static string SessionCount => _propertyKeyMap[nameof(SessionCount)];

            /// <summary>
            /// Original source for the contact with the earliest activity for this company or organization.
            /// One of "ORGANIC_SEARCH", "PAID_SEARCH", "EMAIL_MARKETING", "SOCIAL_MEDIA", "REFERRALS",
            /// "OTHER_CAMPAIGNS", "DIRECT_TRAFFIC", "OFFLINE", "PAID_SOCIAL".
            /// </summary>
            public static string OriginalSourceType => _propertyKeyMap[nameof(OriginalSourceType)];

            /// <summary>
            /// Additional information about the original source for the contact with the earliest activity for this company or organization.
            /// </summary>
            public static string OriginalSourceData1 => _propertyKeyMap[nameof(OriginalSourceData1)];

            /// <summary>
            /// Additional information about the original source for the contact with the earliest activity for this company or organization.
            /// </summary>
            public static string OriginalSourceData2 => _propertyKeyMap[nameof(OriginalSourceData2)];
        }
    }
}
