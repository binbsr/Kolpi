using Kolpi.Server.Infrastructure.Services;
using Kolpi.Server.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolpi.Server.Extentions
{
    public static class ServicesExtenstions
    {
        public static IServiceCollection AddKolpiServices(this IServiceCollection services)
        {
            services.AddScoped<ITagTypeService, TagTypeService>();
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
