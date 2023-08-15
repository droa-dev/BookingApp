using BookingApp.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookingApp.WebApi.Modules.Common.Extensions
{
    /// <summary>
    ///     Custom Controller Extensions.
    /// </summary>
    public static class CustomControllersExtensions
    {
        /// <summary>
        ///     Add Custom Controller dependencies.
        /// </summary>
        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            services
                .AddHttpContextAccessor()
                .AddMvc(options =>
                {
                    options.Filters.Add<ApiExceptionFilterAttribute>();
                    options.OutputFormatters.RemoveType<TextOutputFormatter>();
                    options.OutputFormatters.RemoveType<StreamOutputFormatter>();
                    options.RespectBrowserAcceptHeader = true;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.Converters.Add(
                        new JsonStringEnumConverter());
                })
                .AddControllersAsServices();
                
            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);

            return services;
        }
    }
}
