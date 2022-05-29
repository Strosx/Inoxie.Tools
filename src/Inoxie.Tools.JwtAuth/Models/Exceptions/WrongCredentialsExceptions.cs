namespace Inoxie.Tools.JwtAuth.Models.Exceptions;

internal class WrongCredentialsException : Exception
{
    public WrongCredentialsException(string message) : base(message)
    {
    }
}
