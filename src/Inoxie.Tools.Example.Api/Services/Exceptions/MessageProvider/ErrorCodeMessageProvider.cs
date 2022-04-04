using Inoxie.Tools.Exceptions.Abstractions;

namespace Inoxie.Tools.Example.Api.Exceptions.MessageProvider;

public class ErrorCodeMessageProvider : IMessageFromErrorCodeProvider
{
    public Task<string> Get(int errorCode)
    {
        return Task.FromResult("Error message for error code " + errorCode);
    }
}
