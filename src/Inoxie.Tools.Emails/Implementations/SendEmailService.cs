using Inoxie.Tools.Emails.Configuration;
using Inoxie.Tools.Emails.Interfaces;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Inoxie.Tools.Emails.Implementations;

internal class SendEmailService<TEmailModel> : ISendEmailService<TEmailModel>
{
    private readonly IEmailBodyProvider<TEmailModel> provider;
    private readonly ISendGridClient sendGridClient;
    private readonly SendGridSettings sendGridSettings;
        
    public SendEmailService(IEmailBodyProvider<TEmailModel> provider,
        ISendGridClient sendGridClient,
        IOptions<SendGridSettings> sendGridSettings)
    {
        this.provider = provider;
        this.sendGridClient = sendGridClient;
        this.sendGridSettings = sendGridSettings.Value;
    }

    public async Task Send(TEmailModel model)
    {
        var message = await provider.CreateMessageAsync(model);
            
        message.AddBcc( new EmailAddress
        {
            Email = sendGridSettings.BackupEmail,
            Name = "Backup",
        });

        await sendGridClient.SendEmailAsync(message);
    }
}