namespace Inoxie.Tools.Search.Options;

internal class AzureIndexSearchOptions<T>
{
    internal string IndexName { get; set; } = string.Empty;

    internal Uri IndexUrl { get; set; }

    internal string ApiKey { get; set; } = string.Empty;

    // retry policy?
    // error polic? 
}