using Inoxie.Tools.AzureSearch.Models;

namespace Inoxie.Tools.AzureSearch.Client;

public interface IAzureSearchClient<T> where T : class, IAzureSearchModel
{
    public Task<ICollection<T>> Search(string search, CancellationToken cancellationToken = default);
}
