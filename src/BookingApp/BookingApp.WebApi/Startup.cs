using BookingApp.Application.Core.Common.Configurations;
using BookingApp.Infrastructure.Core.Configurations;
using BookingApp.WebApi.Modules.Common.Extensions;
using BookingApp.WebApi.Modules.Common.Swagger;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace BookingApp.WebApi
{
    public class Startup
    {
        /// <summary>
        ///     Startup constructor.
        /// </summary>
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddApplicationCore()
                .AddPersistence(Configuration)
                .AddInfrastructure()
                .AddHealthChecks(Configuration)
                .AddVersioning()
                .AddSwagger(Configuration)                
                .AddCustomControllers()
                .AddCustomCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider
            )
        {
            app
                .UseHealthChecks(Configuration)
                .UseCustomCors()
                .UseRouting()
                .UseVersionedSwagger(provider, Configuration, env)
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
