using BookingApp.Domain.Core.Factories;
using BookingApp.Domain.Core.Repositories;
using BookingApp.Domain.Core.Services;
using BookingApp.Infrastructure.Core.Data;
using BookingApp.Infrastructure.Core.Factories;
using BookingApp.Infrastructure.Core.Repositories;
using BookingApp.Infrastructure.Core.Services.Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingApp.Infrastructure.Core.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IQueuesService, AzureStorageQueueService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            services.AddScoped<IBookingFactory, EntityFactory>();
            services.AddScoped<IHotelFactory, EntityFactory>();
            services.AddScoped<IRoomFactory, EntityFactory>();
            services.AddScoped<EntityFactory, EntityFactory>();

            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookingAppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BookingAppDbConnection"));
            });

            return services;
        }
    }
}
