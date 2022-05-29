using Inoxie.Tools.Core.Repository.GuidId.Abstractions;

namespace Inoxie.Tools.JwtAuth.Models.Entities;

public class AccountEntity : IDataEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }

    public ICollection<AccountRoleEntity> Roles { get; set; }
    public ICollection<RefreshTokenEntity> RefreshTokens { get; set; }
}
