using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Example.Api.Domain.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Inoxie.Tools.Example.Api.Controllers;

[Route("api/customers")]
public class CustomersWriteController : ControllerBase
{
    private readonly IWriteService<CustomerInDto> writeService;

    public CustomersWriteController(
        IWriteService<CustomerInDto> writeService)
    {
        this.writeService = writeService;
    }

    [HttpPost]
    public Task<Guid> Create([FromBody] CustomerInDto customerInDto)
    {
        return writeService.CreateAsync(customerInDto);
    }

    [HttpPut]
    public Task Update([FromBody] CustomerInDto customerInDto)
    {
        return writeService.UpdateAsync(customerInDto, customerInDto.Id);
    }

    [HttpDelete]
    public Task Delete(Guid id)
    {
        return writeService.DeleteAsync(id);
    }
}
