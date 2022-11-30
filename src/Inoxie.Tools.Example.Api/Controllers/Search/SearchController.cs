using Inoxie.Tools.ApiServices.GuidId.Abstractions;
using Inoxie.Tools.AzureSearch.Client;
using Inoxie.Tools.DataProcessor.Abstractions.Models;
using Inoxie.Tools.Example.Api.Core.Models;
using Inoxie.Tools.Example.Api.Domain.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Inoxie.Tools.Example.Api.Controllers.Search;

[Route("api/search")]
public class SearchController : ControllerBase
{
    private readonly IAzureSearchClient<CustomerEntity> _searchClient;

    public SearchController(IAzureSearchClient<CustomerEntity> searchClient)
    {
        _searchClient = searchClient;
    }

    [HttpGet]
    public Task<ICollection<CustomerEntity>> GetAll([FromQuery] string name, CancellationToken cancellationToken)    
        => _searchClient.Search(name, cancellationToken);
}
