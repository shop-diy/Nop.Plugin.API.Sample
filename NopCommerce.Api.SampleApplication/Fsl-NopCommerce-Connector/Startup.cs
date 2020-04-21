using Fsl.NopCommerce.Api.Connector.Repositories;
using Fsl.NopCommerce.Api.Connector.Services;
using Fsl.NopCommerce.Api.Connector.Services.Acumatica;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Net.Http;

namespace Fsl.NopCommerce.Api.Connector
{
    public class Startup
    {
        private const string JsonContentType = "application/json";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddHttpClient<NopCommerceApiService>()
                .ConfigureHttpClient((sp, httpClient) =>
                {
                    // We can use sp here to get configuration via DI
                    // and configure httpClient
                    httpClient.DefaultRequestHeaders.Remove("Accept");
                    httpClient.DefaultRequestHeaders.Add("Accept", JsonContentType);
                    httpClient.DefaultRequestHeaders.Add("User-Agent", GetType().Assembly.GetName().Name);
                });
            services.AddHttpClient<AcumaticaApiService>()
                .ConfigureHttpClient((sp, httpClient) =>
                {
                    // We can use sp here to get configuration via DI
                    // and configure httpClient
                    httpClient.DefaultRequestHeaders.Remove("Accept");
                    httpClient.DefaultRequestHeaders.Add("Accept", JsonContentType);

                })
                .ConfigurePrimaryHttpMessageHandler(x => new HttpClientHandler
                {
                    UseCookies = true,
                    CookieContainer = new CookieContainer()
                });
            services.AddHubSpotServices(GetType().Assembly.GetName().Name);
            services.AddScoped<CustomerRepository, CustomerRepository>();
            services.AddScoped<ProductRepository, ProductRepository>();
            services.AddTransient<AcumaticaRepository, AcumaticaRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
