namespace Inoxie.Tools.Exceptions.Models;

public class InoxieException : Exception
{
    public InoxieException(string message) : base(message)
    {
    }

    public InoxieException(string message, int errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }

    public int ErrorCode { get; set; }
}

