using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public partial class HubSpotProperties
    {
        public static class LineItem
        {
            internal static readonly Dictionary<string, string> _propertyKeyMap = new Dictionary<string, string>
            {
                { nameof(Amount), "amount" },
                { nameof(Description), "description" },
                { nameof(Discount), "discount" },
                { nameof(ACV), "hs_acv" },
                { nameof(ARR), "hs_arr" },
                { nameof(MRR), "hs_mrr" },
                { nameof(UnitCost), "hs_cost_of_goods_sold" },
                { nameof(CreateDate), "createdate" },
                { nameof(DiscountPercentage), "hs_discount_percentage" },
                { nameof(Currency), "hs_line_item_currency_code" },
                { nameof(PositionOnQuote), "hs_position_on_quote" },
                { nameof(ProductId), "hs_product_id" },
                { nameof(RecurringBillingStartDate), "hs_recurring_billing_start_date" },
                { nameof(RecurringBillingEndDate), "hs_recurring_billing_end_date" },
                { nameof(RecurringBillingPeriod), "hs_recurring_billing_period" },
                { nameof(RecurringBillingFrequency), "recurringbillingfrequency" },
                { nameof(SKU), "hs_sku" },
                { nameof(SyncAmount), "hs_sync_amount" },
                { nameof(TCV), "hs_tcv" },
                { nameof(TermInMonths), "hs_term_in_months" },
                { nameof(ProductName), "name" },
                { nameof(UnitPrice), "price" },
                { nameof(Quantity), "quantity" },
                { nameof(Tax), "tax" },
            };

            /// <summary>
            /// The amount of a line item.
            /// </summary>
            public static string Amount => _propertyKeyMap[nameof(Amount)];

            /// <summary>
            /// Full description of the product.
            /// </summary>
            public static string Description => _propertyKeyMap[nameof(Description)];

            /// <summary>
            /// The discount amount applied.
            /// </summary>
            public static string Discount => _propertyKeyMap[nameof(Discount)];

            /// <summary>
            /// The annual contract value of this product.
            /// </summary>
            public static string ACV => _propertyKeyMap[nameof(ACV)];

            /// <summary>
            /// The annual recurring revenue of this product.
            /// </summary>
            public static string ARR => _propertyKeyMap[nameof(ARR)];

            /// <summary>
            /// The monthly recurring revenue of this product.
            /// </summary>
            public static string MRR => _propertyKeyMap[nameof(MRR)];

            /// <summary>
            /// The amount that sold goods cost the customer.
            /// </summary>
            public static string UnitCost => _propertyKeyMap[nameof(UnitCost)];

            /// <summary>
            /// The date the line item was created.
            /// </summary>
            public static string CreateDate => _propertyKeyMap[nameof(CreateDate)];

            /// <summary>
            /// The discount percentage applied.
            /// </summary>
            public static string DiscountPercentage => _propertyKeyMap[nameof(DiscountPercentage)];

            /// <summary>
            /// Currency code for the line item.
            /// </summary>
            public static string Currency => _propertyKeyMap[nameof(Currency)];

            /// <summary>
            /// The order which the line item appears on the quotes.
            /// </summary>
            public static string PositionOnQuote => _propertyKeyMap[nameof(PositionOnQuote)];

            /// <summary>
            /// ID of the product from which this was copied.
            /// </summary>
            public static string ProductId => _propertyKeyMap[nameof(ProductId)];

            /// <summary>
            /// Recurring billing start date for a line item.
            /// </summary>
            public static string RecurringBillingStartDate => _propertyKeyMap[nameof(RecurringBillingStartDate)];

            /// <summary>
            /// Recurring billing end date for a line item.
            /// </summary>
            public static string RecurringBillingEndDate => _propertyKeyMap[nameof(RecurringBillingEndDate)];

            /// <summary>
            /// Product recurring billing duration.
            /// </summary>
            public static string RecurringBillingPeriod => _propertyKeyMap[nameof(RecurringBillingPeriod)];

            /// <summary>
            /// How frequently the product is billed. The billing frequency here will inform the
            /// pricing calculation for deals and quotes. One of "" (one-time), "monthly", "quarterly",
            /// "per_six_months" (semi-annually), "annually", "per_two_years", "per_three_years".
            /// </summary>
            public static string RecurringBillingFrequency => _propertyKeyMap[nameof(RecurringBillingFrequency)];

            /// <summary>
            /// Unique product identifier.
            /// </summary>
            public static string SKU => _propertyKeyMap[nameof(SKU)];

            /// <summary>
            /// The amount set by Ecommerce sync.
            /// </summary>
            public static string SyncAmount => _propertyKeyMap[nameof(SyncAmount)];

            /// <summary>
            /// The total contract value of this product.
            /// </summary>
            public static string TCV => _propertyKeyMap[nameof(TCV)];

            /// <summary>
            /// The number of months in the term of this product.
            /// </summary>
            public static string TermInMonths => _propertyKeyMap[nameof(TermInMonths)];

            /// <summary>
            /// The name of the product.
            /// </summary>
            public static string ProductName => _propertyKeyMap[nameof(ProductName)];

            /// <summary>
            /// The cost of the product.
            /// </summary>
            public static string UnitPrice => _propertyKeyMap[nameof(UnitPrice)];

            /// <summary>
            /// How many units of a product are in this line item.
            /// </summary>
            public static string Quantity => _propertyKeyMap[nameof(Quantity)];

            /// <summary>
            /// The tax amount applied.
            /// </summary>
            public static string Tax => _propertyKeyMap[nameof(Tax)];
        }
    }
}
