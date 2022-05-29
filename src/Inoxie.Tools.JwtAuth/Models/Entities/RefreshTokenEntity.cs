using Inoxie.Tools.Core.Repository.GuidId.Abstractions;

namespace Inoxie.Tools.JwtAuth.Models.Entities;

public class RefreshTokenEntity : IDataEntity
{
    public Guid Id { get; set; }
    public string Token { get; set; }
    public DateTime CreateDate { get; set; }

    public Guid AccountId { get; set; }
    public AccountEntity Account { get; set; }
}