using Inoxie.Tools.Emails.Models;
using SendGrid.Helpers.Mail;

namespace Inoxie.Tools.Emails.Interfaces;

public interface IEmailBodyProvider<T>
    where T : BaseEmailModel
{
    Task<SendGridMessage> CreateMessageAsync(T model);
}