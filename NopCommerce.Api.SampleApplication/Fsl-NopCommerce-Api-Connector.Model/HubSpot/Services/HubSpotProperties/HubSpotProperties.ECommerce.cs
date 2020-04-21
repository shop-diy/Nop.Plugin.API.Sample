using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public partial class HubSpotProperties
    {
        public static class ECommerce
        {
            internal static readonly Dictionary<string, string> _propertyKeyMap = new Dictionary<string, string>
            {
                { nameof(DiscountAmount), "ip__ecomm_bridge__discount_amount" },
                { nameof(IsSynced), "ip__ecomm_bridge__ecomm_synced" },
                { nameof(SourceAppId), "ip__ecomm_bridge__source_app_id" },
                { nameof(SourceStore), "ip__ecomm_bridge__source_store_id" },
            };

            /// <summary>
            /// The discount on the line item as an amount.
            /// </summary>
            public static string DiscountAmount => _propertyKeyMap[nameof(DiscountAmount)];

            /// <summary>
            /// Whether or not this line item being synced with an ecommerce app or integration.
            /// </summary>
            public static string IsSynced => _propertyKeyMap[nameof(IsSynced)];

            /// <summary>
            /// The ID of the ecommerce app that created this line item.
            /// </summary>
            public static string SourceAppId => _propertyKeyMap[nameof(SourceAppId)];

            /// <summary>
            /// The name of the store that created this line item.
            /// </summary>
            public static string SourceStore => _propertyKeyMap[nameof(SourceStore)];
        }
    }
}
