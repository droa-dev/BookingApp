using BookingApp.Application.Core.Common.Configurations;
using BookingApp.Infrastructure.Core.Configurations;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(RoomProcessor.Startup))]

namespace RoomProcessor
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;

            builder.Services
            .AddApplicationCore()
            .AddPersistence(configuration)
            .AddInfrastructure();
        }
    }
}
