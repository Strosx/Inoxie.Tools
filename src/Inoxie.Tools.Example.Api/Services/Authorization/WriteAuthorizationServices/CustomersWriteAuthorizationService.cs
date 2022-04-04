using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Example.Api.Domain.Customers;

namespace Inoxie.Tools.Example.Api.Services.WriteAuthorizationServices;

public class CustomersWriteAuthorizationService : IWriteAuthorizationService<CustomerInDto>
{
    public Task<bool> AuthorizeAsync(CustomerInDto dto)
    {
        return Task.FromResult(true);
    }

    public Task<bool> AuthorizeDeleteAsync(Guid id)
    {
        return Task.FromResult(true);
    }
}
