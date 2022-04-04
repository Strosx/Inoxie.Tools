using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Example.Api.Core.Models;

public class CustomerEntity : IDataEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedDate { get; set; }
}
