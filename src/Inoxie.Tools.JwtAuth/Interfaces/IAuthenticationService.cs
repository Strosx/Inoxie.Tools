using Inoxie.Tools.JwtAuth.Models.Domain;

namespace Inoxie.Tools.JwtAuth.Interfaces;
public interface IAuthenticationService
{
    Task<AuthenticationOutDto> AuthenticateAsync(string username, string password);
}