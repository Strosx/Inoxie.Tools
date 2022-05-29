using Inoxie.Tools.Core.Repository.GuidId.Abstractions;

namespace Inoxie.Tools.JwtAuth.Models.Entities;

public class RoleEntity : IDataEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
