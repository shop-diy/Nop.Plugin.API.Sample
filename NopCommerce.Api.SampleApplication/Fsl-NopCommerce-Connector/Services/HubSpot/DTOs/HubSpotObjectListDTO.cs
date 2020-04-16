namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs
{
    public class HubSpotObjectListDTO
    {
        public HubSpotObjectDTO[] Results { get; set; }
        public HubSpotPagingDTO Paging { get; set; }
    }
}
