using Inoxie.Tools.Emails.Configuration;
using Inoxie.Tools.Emails.Interfaces;
using Inoxie.Tools.Emails.Models;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;

namespace Inoxie.Tools.Emails.Implementations;

internal class BaseEmailBodyProvider<TEmailModel> : IEmailBodyProvider<TEmailModel>
    where TEmailModel : BaseEmailModel, ITemplatedEmailModel
{
    private readonly IEmailTemplateIdProvider<TEmailModel> emailTemplateIdProvider;
    private readonly IOptions<SendGridSettings> options;

    public BaseEmailBodyProvider(
        IEmailTemplateIdProvider<TEmailModel> emailTemplateIdProvider,
        IOptions<SendGridSettings> options)
    {
        this.emailTemplateIdProvider = emailTemplateIdProvider;
        this.options = options;
    }

    public Task<SendGridMessage> CreateMessageAsync(TEmailModel model)
    {
        model.Sender = new EmailAddress(options.Value.SendFromEmail, options.Value.SendFromName);
        model.TemplateId = emailTemplateIdProvider.GetTemplateId(model);

        var msg = new SendGridMessage();

        msg.SetFrom(model.Sender);
        msg.AddTo(model.Recipient);
        msg.SetTemplateId(model.TemplateId);
        msg.SetTemplateData(model);
        return Task.FromResult(msg);
    }
}