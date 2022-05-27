using SendGrid.Helpers.Mail;

namespace Inoxie.Tools.Emails.Interfaces;

public interface IEmailBodyProvider<in T>
{
    Task<SendGridMessage> CreateMessageAsync(T model);
}