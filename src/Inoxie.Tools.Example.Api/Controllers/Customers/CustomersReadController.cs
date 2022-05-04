using Inoxie.Tools.ApiServices.GuidId.Abstractions;
using Inoxie.Tools.DataProcessor.Abstractions.Models;
using Inoxie.Tools.Example.Api.Domain.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Inoxie.Tools.Example.Api.Controllers;

[Route("api/customers")]
public class CustomersReadController : ControllerBase
{
    private readonly IFilterReadService<CustomerOutDto, BaseSearchableFilterModel> filterReadService;

    public CustomersReadController(
        IFilterReadService<CustomerOutDto, BaseSearchableFilterModel> filterReadService)
    {
        this.filterReadService = filterReadService;
    }


    [HttpPost("filter")]
    public Task<PagedDataResponse<CustomerOutDto>> Filter([FromBody] BaseSearchableFilterModel filterModel)
    {
        return filterReadService.FilterAsync(filterModel);
    }

    [HttpGet("all")]
    public Task<List<CustomerOutDto>> GetAll()
    {
        return filterReadService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public Task<CustomerOutDto> Get(Guid id)
    {
        return filterReadService.GetAsync(id);
    }

    [HttpPost("firstFilter")]
    public Task<CustomerOutDto> FirstByFilter([FromBody] BaseSearchableFilterModel filterModel)
    {
        return filterReadService.GetByFilterFirstAsync(filterModel);
    }
}
