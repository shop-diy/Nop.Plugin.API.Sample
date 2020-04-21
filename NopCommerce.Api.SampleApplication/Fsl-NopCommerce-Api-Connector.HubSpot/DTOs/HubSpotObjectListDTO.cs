namespace Fsl.NopCommerce.Api.Connector.DTOs.HubSpot
{
    class HubSpotObjectListDTO
    {
        public HubSpotObjectDTO[] Results { get; set; }
        public HubSpotPagingDTO Paging { get; set; }
    }
}
