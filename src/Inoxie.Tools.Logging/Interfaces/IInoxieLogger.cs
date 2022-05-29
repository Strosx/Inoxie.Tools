namespace Inoxie.Tools.Logging.Interfaces;

public interface IInoxieLogger<T>
{
    void LogInformation<T0>(string message, T0 arg0);
    void LogInformation<T0, T1>(string message, T0 arg0, T1 arg1);
    void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

    void LogError<T0>(string message, T0 arg0);
    void LogError<T0, T1>(string message, T0 arg0, T1 arg1);
    void LogError<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);
}

