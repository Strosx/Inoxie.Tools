using Inoxie.Tools.AzureSearch.Models;

namespace Inoxie.Tools.AzureSearch.Options;

internal class AzureIndexSearchOptions<T> where T : class, IAzureSearchModel
{
    internal string IndexName { get; set; } = string.Empty;

    internal Uri IndexUrl { get; set; }
}