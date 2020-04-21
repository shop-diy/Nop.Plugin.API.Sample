namespace Fsl.NopCommerce.Api.Connector.DTOs.HubSpot
{
    class HubSpotAssociationsDTO
    {
        public HubSpotAssociationLinkDTO Companies { get; set; }
        public HubSpotAssociationLinkDTO Contacts { get; set; }
        public HubSpotAssociationLinkDTO Deals { get; set; }
        public HubSpotAssociationLinkDTO Line_Items { get; set; }
        public HubSpotAssociationLinkDTO Products { get; set; }
        public HubSpotAssociationLinkDTO Tickets { get; set; }
        public HubSpotAssociationLinkDTO Quotes { get; set; }
    }

    class HubSpotAssociationLinkDTO
    {
        public HubSpotAssociationDTO[] Results { get; set; }
    }

    class HubSpotAssociationDTO
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }
}
