using Inoxie.Tools.Emails.Configuration;
using Inoxie.Tools.Emails.Implementations;
using Inoxie.Tools.Emails.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;

namespace Inoxie.Tools.Emails.DI;

public static class ToolsEmailsDIExtensions
{
    public static void AddInoxieEmailsTool(this IServiceCollection services, IConfiguration configuration)
    {
        var sendGridApiKey = configuration.GetSection(SendGridSettings.SendGridKey).GetValue<string>("ApiKey");
        var client = new SendGridClient(sendGridApiKey);

        services.Configure<SendGridSettings>(options => configuration.GetSection(SendGridSettings.SendGridKey).Bind(options));
        services.AddScoped<ISendGridClient, SendGridClient>(_ => client);
        services.AddScoped(typeof(IEmailBodyProvider<>), typeof(BaseEmailBodyProvider<>));
        services.AddScoped(typeof(ISendEmailService<>), typeof(SendEmailService<>));
    }
}