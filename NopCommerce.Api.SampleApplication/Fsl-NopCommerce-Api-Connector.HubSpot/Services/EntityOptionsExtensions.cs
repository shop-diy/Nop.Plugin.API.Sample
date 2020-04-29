using Fsl.NopCommerce.Api.Connector.Model.HubSpot;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services
{
    static class EntityOptionsExtensions
    {
        public static string[] ToAssociationsArray<TEntity>(this EntityOptions options) where TEntity : HubSpotEntity
        {
            var associations = new List<string>();

            if (!options.ExcludeLineItems && !typeof(TEntity).Equals(typeof(HubSpotLineItem)))
                associations.Add("line_items");

            if (!options.ExcludeCompanies && !typeof(TEntity).Equals(typeof(HubSpotCompany)))
                associations.Add("companies");

            if (!options.ExcludeContacts && !typeof(TEntity).Equals(typeof(HubSpotContact)))
                associations.Add("contacts");

            if (!options.ExcludeDeals)
                associations.Add("deals");

            if (!options.ExcludeProducts && !typeof(TEntity).Equals(typeof(HubSpotProduct)))
                associations.Add("products");

            return associations.ToArray();
        }
    }
}
