namespace Inoxie.Tools.Search.Client;

public interface IAzureSearchClient<T> where T : class
{
    public Task<ICollection<T>> Search(string search, CancellationToken cancellationToken = default);
}
