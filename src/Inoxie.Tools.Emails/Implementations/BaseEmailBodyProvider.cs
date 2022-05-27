using Inoxie.Tools.Emails.Interfaces;
using Inoxie.Tools.Emails.Models;
using SendGrid.Helpers.Mail;

namespace Inoxie.Tools.Emails.Implementations;

internal class BaseEmailBodyProvider<TEmailModel> : IEmailBodyProvider<TEmailModel> 
    where TEmailModel : BaseEmailModel
{
    public Task<SendGridMessage> CreateMessageAsync(TEmailModel model)
    {
        var msg = new SendGridMessage();

        msg.SetFrom(model.Sender);
        msg.AddTo(model.Recipient);
        msg.SetTemplateId(model.TemplateId);
        msg.SetTemplateData(model);
        return Task.FromResult(msg);
    }
}