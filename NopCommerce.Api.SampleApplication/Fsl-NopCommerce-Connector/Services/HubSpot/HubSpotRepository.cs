using System;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public class HubSpotRepository
    {
        private readonly Lazy<HubSpotQuoteRepository> _quotes;
        private readonly Lazy<HubSpotCompanyRepository> _companies;
        private readonly Lazy<HubSpotLineItemRepository> _lineItems;
        private readonly Lazy<HubSpotContactRepository> _contacts;

        public HubSpotRepository(HubSpotService hubSpotService)
        {
            _quotes = new Lazy<HubSpotQuoteRepository>(() => new HubSpotQuoteRepository(hubSpotService));
            _companies = new Lazy<HubSpotCompanyRepository>(() => new HubSpotCompanyRepository(hubSpotService));
            _lineItems = new Lazy<HubSpotLineItemRepository>(() => new HubSpotLineItemRepository(hubSpotService));
            _contacts = new Lazy<HubSpotContactRepository>(() => new HubSpotContactRepository(hubSpotService));
        }

        public HubSpotQuoteRepository Quotes => _quotes.Value;
        public HubSpotCompanyRepository Companies => _companies.Value;
        public HubSpotLineItemRepository LineItems => _lineItems.Value;
        public HubSpotContactRepository Contacts => _contacts.Value;
    }
}
