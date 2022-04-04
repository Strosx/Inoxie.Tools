namespace Inoxie.Tools.Example.Api.Domain.Customers;

public class CustomerOutDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
}
