namespace Inoxie.Tools.Emails.Configuration;

public class SendGridSettings
{
    public const string SendGridKey = "SendGridSettings";

    public string ApiKey { get; set; }
    public string BackupEmail { get; set; }
    public string SendFromEmail { get; set; }
    public string SendFromName { get; set; }
}