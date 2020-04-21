using Fsl.NopCommerce.Api.Connector.Model.HubSpot;
using Fsl.NopCommerce.Api.Connector.Services.HubSpot;
using Microsoft.Extensions.DependencyInjection;

namespace Fsl.NopCommerce.Api.Connector
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHubSpotServices(this IServiceCollection services, string userAgent = "FSL HubSpot API Service")
        {
            services.AddHttpClient<IHubSpotService, HubSpotService>()
                .ConfigureHttpClient((sp, httpClient) =>
                {
                    // We can use sp here to get configuration via DI
                    // and configure httpClient
                    httpClient.DefaultRequestHeaders.Remove("Accept");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
                });

            services.AddTransient<IHubSpotReadOnlyRepository<HubSpotQuote>, HubSpotQuoteRepository>();
            services.AddTransient<IHubSpotReadOnlyRepository<HubSpotCompany>, HubSpotCompanyRepository>();
            services.AddTransient<IHubSpotReadOnlyRepository<HubSpotContact>, HubSpotContactRepository>();
            services.AddTransient<IHubSpotReadOnlyRepository<HubSpotLineItem>, HubSpotLineItemRepository>();

            services.AddScoped<HubSpotContext, HubSpotContext>(ctx => new HubSpotContext(ctx));

            return services;
        }
    }
}
