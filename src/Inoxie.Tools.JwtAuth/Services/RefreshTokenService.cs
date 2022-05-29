using Inoxie.Tools.Core.Repository.GuidId.Abstractions;
using Inoxie.Tools.JwtAuth.Interfaces;
using Inoxie.Tools.JwtAuth.Models;
using Inoxie.Tools.JwtAuth.Models.Domain;
using Inoxie.Tools.JwtAuth.Models.Entities;
using Inoxie.Tools.JwtAuth.Models.Exceptions;
using Inoxie.Tools.JwtAuth.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Inoxie.Tools.JwtAuth.Services;

internal class RefreshTokenService : IRefreshTokenService
{
    private readonly IReadRepository<RefreshTokenEntity> refreshTokensReadRepository;
    private readonly JwtTokenGenerator jwtTokenGenerator;
    private readonly IOptions<JwtAuthConfiguration> options;

    public RefreshTokenService(
        IReadRepository<RefreshTokenEntity> refreshTokensReadRepository,
        JwtTokenGenerator jwtTokenGenerator,
        IOptions<JwtAuthConfiguration> options)
    {
        this.refreshTokensReadRepository = refreshTokensReadRepository;
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.options = options;
    }


    public async Task<AuthenticationOutDto> RefreshTokenAsync(RefreshTokenInDto refreshTokenInDto)
    {
        var refreshTokenEntity = await refreshTokensReadRepository
            .AsQueryable()
            .Include(x => x.Account)
                .ThenInclude(x => x.Roles)
                    .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(f => f.Account.Username == refreshTokenInDto.Username && f.Token == refreshTokenInDto.RefreshToken);

        if (refreshTokenEntity == null)
        {
            throw new WrongCredentialsException("Invalid refresh token");
        }

        var jwtToken = jwtTokenGenerator.GenerateJwtToken(refreshTokenEntity.Account);
        return new AuthenticationOutDto()
        {
            AccessToken = jwtToken,
            RefreshToken = refreshTokenEntity.Token,
            ExpirationDate = DateTime.UtcNow.AddSeconds(options.Value.TokenExpirationInSeconds)
        };
    }
}
