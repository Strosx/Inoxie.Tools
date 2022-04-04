using Inoxie.Tools.Exceptions.Abstractions;

namespace Inoxie.Tools.Exceptions.Services;

internal class DefaultMessageFromErrorCodeProvider : IMessageFromErrorCodeProvider
{
    public Task<string> Get(int errorCode)
    {
        throw new Exception("If you are using InoxieErrorCodeException you must implement MessageFromErrorCodeProvider!");
    }
}
