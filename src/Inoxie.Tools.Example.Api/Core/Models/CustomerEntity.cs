using Inoxie.Tools.AzureSearch.Models;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;

namespace Inoxie.Tools.Example.Api.Core.Models;

public class CustomerEntity : IDataEntity, IAzureSearchModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedDate { get; set; }
}