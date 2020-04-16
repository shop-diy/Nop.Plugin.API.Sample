namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot.DTOs
{
    public class HubSpotAssociationsDTO
    {
        public HubSpotAssociationLinkDTO Companies { get; set; }
        public HubSpotAssociationLinkDTO Contacts { get; set; }
        public HubSpotAssociationLinkDTO Deals { get; set; }
        public HubSpotAssociationLinkDTO Line_Items { get; set; }
        public HubSpotAssociationLinkDTO Products { get; set; }
        public HubSpotAssociationLinkDTO Tickets { get; set; }
        public HubSpotAssociationLinkDTO Quotes { get; set; }
    }

    public class HubSpotAssociationLinkDTO
    {
        public HubSpotAssociationDTO[] Results { get; set; }
    }

    public class HubSpotAssociationDTO
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }
}
