using Fsl.NopCommerce.Api.Connector.Services.Acumatica.DTOs;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Mapping
{
    public class HubSpotQuoteToAcumeticaSalesOrderMapper : IObjectMapper<HubSpotObjectDTO, AcumaticaSalesOrderDTO>
    {
        public Type SourceType { get; } = typeof(HubSpotObjectDTO);

        public Type DestinationType { get; } = typeof(AcumaticaSalesOrderDTO);

        public bool ToObject(HubSpotObjectDTO source, out AcumaticaSalesOrderDTO result)
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(HubSpotObjectDTO source, AcumaticaSalesOrderDTO dest)
        {
            throw new NotImplementedException();
        }
    }
}
