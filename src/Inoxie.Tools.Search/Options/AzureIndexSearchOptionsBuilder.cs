namespace Inoxie.Tools.Search.Options;

public class AzureIndexSearchOptionsBuilder<T>
{
    private readonly AzureIndexSearchOptions<T> _options;

    private AzureIndexSearchOptionsBuilder()
    {
        _options = new AzureIndexSearchOptions<T>();
    }

    internal static AzureIndexSearchOptionsBuilder<T> Init => new();

    public AzureIndexSearchOptionsBuilder<T> AddIndexUrl(string url)
    {
        _options.IndexUrl = new Uri(url);
        return this;
    }

    public AzureIndexSearchOptionsBuilder<T> AddApiKey(string key)
    {
        _options.ApiKey = key;
        return this;
    }

    public AzureIndexSearchOptionsBuilder<T> AddIndexName(string name)
    {
        _options.IndexName = name;
        return this;
    }

    internal virtual AzureIndexSearchOptions<T> Options
        => _options;
}
