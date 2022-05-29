using Inoxie.Tools.JwtAuth.Models.Domain;

namespace Inoxie.Tools.JwtAuth.Interfaces;

public interface IRefreshTokenService
{
    Task<AuthenticationOutDto> RefreshTokenAsync(RefreshTokenInDto refreshTokenInDto);
}