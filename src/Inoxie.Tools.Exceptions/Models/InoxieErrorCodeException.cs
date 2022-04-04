namespace Inoxie.Tools.Exceptions.Models;

public class InoxieErrorCodeException : InoxieException
{
    public InoxieErrorCodeException(Enum errorCode) : base("")
    {
        ErrorCode = Convert.ToInt32(errorCode);
    }

    public InoxieErrorCodeException(int errorCode) : base("")
    {
        ErrorCode = errorCode;
    }
}