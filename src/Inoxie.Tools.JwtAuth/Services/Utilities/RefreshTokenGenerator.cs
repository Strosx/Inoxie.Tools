using Inoxie.Tools.Core.Repository.GuidId.Abstractions;
using Inoxie.Tools.JwtAuth.Models.Entities;

namespace Inoxie.Tools.JwtAuth.Services.Utilities;

public class RefreshTokenGenerator
{
    private readonly IWriteRepository<RefreshTokenEntity> refreshTokensWriteRepository;

    public RefreshTokenGenerator(IWriteRepository<RefreshTokenEntity> refreshTokensWriteRepository)
    {
        this.refreshTokensWriteRepository = refreshTokensWriteRepository;
    }

    public async Task<string> GenerateRefreshToken(Guid accountId)
    {
        var refreshToken = Guid.NewGuid().ToString("N");

        await refreshTokensWriteRepository.CreateAsync(new RefreshTokenEntity()
        {
            AccountId = accountId,
            Token = refreshToken,
            CreateDate = DateTime.UtcNow,
        });

        return refreshToken;
    }
}
