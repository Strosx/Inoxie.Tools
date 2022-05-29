using Inoxie.Tools.Core.Repository.GuidId.Abstractions;

namespace Inoxie.Tools.JwtAuth.Models.Entities;

public class AccountRoleEntity : IDataEntity
{
    public Guid Id { get; set; }

    public Guid AccountId { get; set; }
    public AccountEntity Account { get; set; }

    public Guid RoleId { get; set; }
    public RoleEntity Role { get; set; }
}
