using System;
using System.Collections.Generic;
using System.Linq;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public sealed class EntityOptions
    {
        public string ExcludedAssociations { get; set; }

        public bool ExcludeCompanies => ExcludedAssociations != null && (
                                          ExcludedAssociations.Contains("companies", StringComparison.OrdinalIgnoreCase) ||
                                          ExcludedAssociations.Contains("company", StringComparison.OrdinalIgnoreCase)
                                        );
        public bool ExcludeContacts => ExcludedAssociations != null && (
                                         ExcludedAssociations.Contains("contacts", StringComparison.OrdinalIgnoreCase) ||
                                         ExcludedAssociations.Contains("contact", StringComparison.OrdinalIgnoreCase)
                                       );
        public bool ExcludeDeals => ExcludedAssociations != null && (
                                      ExcludedAssociations.Contains("deals", StringComparison.OrdinalIgnoreCase) ||
                                      ExcludedAssociations.Contains("deal", StringComparison.OrdinalIgnoreCase)
                                    );
        public bool ExcludeLineItems => ExcludedAssociations != null && (
                                          ExcludedAssociations.Contains("lineitems", StringComparison.OrdinalIgnoreCase) ||
                                          ExcludedAssociations.Contains("lineitem", StringComparison.OrdinalIgnoreCase) ||
                                          ExcludedAssociations.Contains("line_items", StringComparison.OrdinalIgnoreCase) ||
                                          ExcludedAssociations.Contains("line_item", StringComparison.OrdinalIgnoreCase)
                                        );
        public bool ExcludeQuotes => ExcludedAssociations != null && (
                                       ExcludedAssociations.Contains("quotes", StringComparison.OrdinalIgnoreCase) ||
                                       ExcludedAssociations.Contains("quote", StringComparison.OrdinalIgnoreCase)
                                     );
        public bool ExcludeProducts => ExcludedAssociations != null && (
                                       ExcludedAssociations.Contains("products", StringComparison.OrdinalIgnoreCase) ||
                                       ExcludedAssociations.Contains("product", StringComparison.OrdinalIgnoreCase)
                                     );
    }

    public static class EntityOptionsExtensions
    {
        public static EntityOptions ExcludeAssociations(this EntityOptions options, params string[] associations)
        {
            if (associations == null && associations.Length > 0)
            {
                HashSet<string> exclusions = new HashSet<string>(string.IsNullOrWhiteSpace(options.ExcludedAssociations) ? new string[] { } : options.ExcludedAssociations.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()), StringComparer.OrdinalIgnoreCase);

                foreach (var association in associations.Where(a => !string.IsNullOrWhiteSpace(a)))
                {
                    exclusions.Add(association);
                }

                options.ExcludedAssociations = string.Join(',', exclusions);
            }

            return options;
        }
    }
}
