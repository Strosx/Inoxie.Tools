using Inoxie.Tools.Emails.Interfaces;
using SendGrid.Helpers.Mail;

namespace Inoxie.Tools.Emails.Models;

public abstract class BaseEmailModel : ITemplatedEmailModel
{
    public string TemplateId { get; set; }
    public EmailAddress Sender { get; set; }
    public EmailAddress Recipient { get; set; }

    public abstract string TemplateConfigurationKey { get; }
}