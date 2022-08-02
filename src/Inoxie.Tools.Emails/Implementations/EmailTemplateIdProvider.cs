using Inoxie.Tools.Emails.Configuration;
using Inoxie.Tools.Emails.Interfaces;
using Inoxie.Tools.Emails.Models;
using Microsoft.Extensions.Configuration;

namespace Inoxie.Tools.Emails.Implementations;

internal class EmailTemplateIdProvider<TModel> : IEmailTemplateIdProvider<TModel>
    where TModel : BaseEmailModel, ITemplatedEmailModel
{
    private readonly IConfiguration configuration;

    public EmailTemplateIdProvider(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string GetTemplateId(TModel model)
    {
        return configuration.GetValue<string>($"{SendGridSettings.SendGridKey}:{model.TemplateConfigurationKey}");
    }
}