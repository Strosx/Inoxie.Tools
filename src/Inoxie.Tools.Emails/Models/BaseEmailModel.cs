using SendGrid.Helpers.Mail;

namespace Inoxie.Tools.Emails.Models;

public class BaseEmailModel
{
    public string TemplateId { get; set; }
    public EmailAddress Sender { get; set; }
    public EmailAddress Recipient { get; set; }
}