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

internal class AuthenticationService : IAuthenticationService
{
    private readonly IOptions<JwtAuthConfiguration> configuration;
    private readonly IReadRepository<AccountEntity> accountsReadRepository;
    private readonly RefreshTokenGenerator refreshTokenGenerator;
    private readonly JwtTokenGenerator jwtTokenGenerator;

    public AuthenticationService(
        IOptions<JwtAuthConfiguration> configuration,
        IReadRepository<AccountEntity> accountsReadRepository,
        RefreshTokenGenerator refreshTokenGenerator,
        JwtTokenGenerator jwtTokenGenerator)
    {
        this.configuration = configuration;
        this.accountsReadRepository = accountsReadRepository;
        this.refreshTokenGenerator = refreshTokenGenerator;
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationOutDto> AuthenticateAsync(string username, string password)
    {
        var account = await accountsReadRepository
            .AsQueryable()
            .Include(x => x.Roles)
                .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(f => f.Username == username && f.PasswordHash == PasswordHasher.Hash(password));

        if (account == null) throw new WrongCredentialsException("Wrong email or password");

        var jwtToken = jwtTokenGenerator.GenerateJwtToken(account);
        var refreshToken = await refreshTokenGenerator.GenerateRefreshToken(account.Id);

        return new AuthenticationOutDto()
        {
            AccessToken = jwtToken,
            RefreshToken = refreshToken,
            ExpirationDate = DateTime.UtcNow.AddSeconds(configuration.Value.TokenExpirationInSeconds)
        };
    }
}
