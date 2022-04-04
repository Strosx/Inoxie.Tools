namespace Inoxie.Tools.Exceptions.Abstractions;

public interface IMessageFromErrorCodeProvider
{
    public Task<string> Get(int errorCode);
}

