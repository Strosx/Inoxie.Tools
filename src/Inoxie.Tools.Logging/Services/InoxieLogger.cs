using Inoxie.Tools.Logging.Interfaces;
using Microsoft.Extensions.Logging;

namespace Inoxie.Tools.Logging.Services;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2254:Template should be a static expression", Justification = "<Pending>")]
internal class InoxieLogger<T> : IInoxieLogger<T>
{
    private readonly ILogger<T> logger;

    public InoxieLogger(ILogger<T> logger)
    {
        this.logger = logger;
    }

    public void LogError<T0>(string message, T0 arg0)
    {
        if (logger.IsEnabled(LogLevel.Error))
        {
            logger.LogInformation(message, arg0);
        }
    }

    public void LogError<T0, T1>(string message, T0 arg0, T1 arg1)
    {
        if (logger.IsEnabled(LogLevel.Error))
        {
            logger.LogError(message, arg0, arg1);
        }
    }

    public void LogError<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
    {
        if (logger.IsEnabled(LogLevel.Error))
        {
            logger.LogError(message, arg0, arg1, arg2);
        }
    }

    public void LogInformation<T0>(string message, T0 arg0)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(message, arg0);
        }
    }

    public void LogInformation<T0, T1>(string message, T0 arg0, T1 arg1)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(message, arg0, arg1);
        }
    }

    public void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(message, arg0, arg1, arg2);
        }
    }
}
