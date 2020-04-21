using Fsl.NopCommerce.Api.Connector.Model.HubSpot;
using System;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public sealed class HubSpotContext
    {
        private readonly Lazy<IHubSpotReadOnlyRepository<HubSpotQuote>> _quotes;
        private readonly Lazy<IHubSpotReadOnlyRepository<HubSpotCompany>> _companies;
        private readonly Lazy<IHubSpotReadOnlyRepository<HubSpotLineItem>> _lineItems;
        private readonly Lazy<IHubSpotReadOnlyRepository<HubSpotContact>> _contacts;

        public HubSpotContext(IServiceProvider services)
        {
            _quotes = new Lazy<IHubSpotReadOnlyRepository<HubSpotQuote>>(() =>
                services.GetService(typeof(IHubSpotReadOnlyRepository<HubSpotQuote>)) as IHubSpotReadOnlyRepository<HubSpotQuote>);
            _companies = new Lazy<IHubSpotReadOnlyRepository<HubSpotCompany>>(() =>
                services.GetService(typeof(IHubSpotReadOnlyRepository<HubSpotCompany>)) as IHubSpotReadOnlyRepository<HubSpotCompany>);
            _lineItems = new Lazy<IHubSpotReadOnlyRepository<HubSpotLineItem>>(() =>
                services.GetService(typeof(IHubSpotReadOnlyRepository<HubSpotLineItem>)) as IHubSpotReadOnlyRepository<HubSpotLineItem>);
            _contacts = new Lazy<IHubSpotReadOnlyRepository<HubSpotContact>>(() =>
                services.GetService(typeof(IHubSpotReadOnlyRepository<HubSpotContact>)) as IHubSpotReadOnlyRepository<HubSpotContact>);
        }

        public IHubSpotReadOnlyRepository<HubSpotQuote> Quotes => _quotes.Value;
        public IHubSpotReadOnlyRepository<HubSpotCompany> Companies => _companies.Value;
        public IHubSpotReadOnlyRepository<HubSpotLineItem> LineItems => _lineItems.Value;
        public IHubSpotReadOnlyRepository<HubSpotContact> Contacts => _contacts.Value;
    }
}
