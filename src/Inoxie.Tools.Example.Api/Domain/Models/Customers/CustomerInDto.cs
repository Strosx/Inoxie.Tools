using Inoxie.Tools.ApiServices.Attributes;

namespace Inoxie.Tools.Example.Api.Domain.Customers;

public class CustomerInDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [NoUpdate]
    public string Password { get; set; }
}
