using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs
{
    public class HubSpotPagingDTO
    {
        public (string Link, string After) Next { get; set; }
    }
}
