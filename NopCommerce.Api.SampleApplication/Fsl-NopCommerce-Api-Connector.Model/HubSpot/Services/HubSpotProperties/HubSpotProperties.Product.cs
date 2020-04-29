using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public partial class HubSpotProperties
    {
        public static class Product
        {
            internal static readonly Dictionary<string, string> _propertyKeyMap = new Dictionary<string, string>
            {
                { nameof(SKU), "hs_sku" },
                { nameof(Name), "name" },
                { nameof(Description), "description" },
                { nameof(UnitPrice), "price" },
                { nameof(UnitCost), "hs_cost_of_goods_sold" },
                { nameof(UnitDiscount), "discount" },
                { nameof(DiscountPercentage), "hs_discount_percentage" },
                { nameof(FolderId), "hs_folder_id" },
                { nameof(BillingFrequency), "recurringbillingfrequency" },
                { nameof(Tax), "tax" },
            };

            /// <summary>
            /// The unique identifier for this product.
            /// </summary>
            public static string SKU => _propertyKeyMap[nameof(SKU)];

            /// <summary>
            /// The name of this product.
            /// </summary>
            public static string Name => _propertyKeyMap[nameof(Name)];

            /// <summary>
            /// Full description of this product.
            /// </summary>
            public static string Description => _propertyKeyMap[nameof(Description)];

            /// <summary>
            /// The price of this product.
            /// </summary>
            public static string UnitPrice => _propertyKeyMap[nameof(UnitPrice)];

            /// <summary>
            /// The amount that sold goods cost the customer.
            /// </summary>
            public static string UnitCost => _propertyKeyMap[nameof(UnitCost)];

            /// <summary>
            /// The discount amount applied to this product.
            /// </summary>
            public static string UnitDiscount => _propertyKeyMap[nameof(UnitDiscount)];

            /// <summary>
            /// The discount percentage for this product.
            /// </summary>
            public static string DiscountPercentage => _propertyKeyMap[nameof(DiscountPercentage)];

            /// <summary>
            /// The ID of the folder that contains this product.
            /// </summary>
            public static string FolderId => _propertyKeyMap[nameof(FolderId)];

            /// <summary>
            /// How frequently the product is billed. The billing frequency here will inform the pricing calculation for deals and quotes.
            /// </summary>
            public static string BillingFrequency => _propertyKeyMap[nameof(BillingFrequency)];

            /// <summary>
            /// The tax amount applied to this product.
            /// </summary>
            public static string Tax => _propertyKeyMap[nameof(Tax)];
        }
    }
}
