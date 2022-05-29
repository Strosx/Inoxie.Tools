using Inoxie.Tools.JwtAuth.Interfaces;
using Inoxie.Tools.JwtAuth.Models.Domain;
using Inoxie.Tools.JwtAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inoxie.Tools.JwtAuth.Controllers;

[Route("api/authorization")]
public class AuthController : ControllerBase
{

    [HttpPost("authenticate")]
    public Task<AuthenticationOutDto> Authenticate([FromBody] AuthenticationInDto authenticationInDto, [FromServices] IAuthenticationService service)
        => service.AuthenticateAsync(authenticationInDto.Username, authenticationInDto.Password);

    [HttpPost("refreshToken")]
    public Task<AuthenticationOutDto> RefreshToken([FromBody] RefreshTokenInDto refreshTokenInDto, [FromServices] IRefreshTokenService service)
        => service.RefreshTokenAsync(refreshTokenInDto);
}
