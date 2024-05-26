using Kolpi.Infrastructure.External;
using Kolpi.Infrastructure.Services.AnswerOptions;
using Kolpi.Infrastructure.Services.Questions;
using Kolpi.Infrastructure.Services.Tags;
using Kolpi.Infrastructure.Services.TagTypes;
using Kolpi.Infrastructure.TextMatcher;
using Kolpi.Server.Infrastructure.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kolpi.Server.Extensions;
public static class ServicesExtenstions
{
    public static IServiceCollection AddKolpiServices(this IServiceCollection services)
    {
        services.AddScoped<ITagTypeService, TagTypeService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IAnswerOptionService, AnswerOptionService>();
        services.AddScoped<QuestionStatusService>();

        services.AddScoped<QuestionMatcher>();

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
