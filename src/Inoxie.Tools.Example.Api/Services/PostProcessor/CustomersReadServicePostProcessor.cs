using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Example.Api.Domain.Customers;

namespace Inoxie.Tools.Example.Api.Services.PostProcessor;

public class CustomersReadServicePostProcessor : IReadServicePostProcessor<CustomerOutDto>
{
    public Task<CustomerOutDto> ProcessAsync(CustomerOutDto dto)
    {
        dto.PasswordHash = "";
        return Task.FromResult(dto);
    }
}
