using Kolpi.ApplicationCore.Services;
using Kolpi.Infrastructure.External;
using Kolpi.Server.Infrastructure.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kolpi.Server.Extensions
{
    public static class ServicesExtenstions
    {
        public static IServiceCollection AddKolpiServices(this IServiceCollection services)
        {
            services.AddScoped<ITagTypeService, TagTypeService>();
            services.AddScoped<ITagService, TagService>();
            return services;
        }
        public static IServiceCollection AddKolpiLogger(this IServiceCollection services)
        {
            services.AddScoped(typeof(IKolpiLogger<>), typeof(LoggerAdapter<>));
            return services;
        }

        public static IServiceCollection AddKolpiEmailSender(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
