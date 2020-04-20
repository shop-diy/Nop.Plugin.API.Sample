using Fsl.NopCommerce.Api.Connector.Services.HubSpot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Extensions
{
    static class HubSpotContactExtensions
    {
        public static string GetAttention(this HubSpotContact contact)
        {
            if (contact != null)
            {
                if (!string.IsNullOrWhiteSpace(contact.FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(contact.LastName))
                    {
                        return $"{contact.FirstName} {contact.LastName}";
                    }
                    else
                    {
                        return contact.FirstName;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(contact.LastName))
                {
                    return contact.LastName;
                }
            }

            return null;
        }
    }
}
