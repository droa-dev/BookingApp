using BookingApp.Application.Core.Common.Configurations;
using BookingApp.Infrastructure.Core.Configurations;
using Microsoft.Extensions.Hosting;

namespace HotelProcessor
{
    public static class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices((hostBuilderContext, services) =>
                {
                    var configuration = hostBuilderContext.Configuration;
                    services.AddApplicationCore();
                    services.AddPersistence(configuration);
                    services.AddInfrastructure();

                })
                .Build();

            host.Run();
        }
    }
}
