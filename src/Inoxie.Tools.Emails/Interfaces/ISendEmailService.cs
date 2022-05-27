namespace Inoxie.Tools.Emails.Interfaces;

public interface ISendEmailService<in T>
{
    Task Send(T model);
}