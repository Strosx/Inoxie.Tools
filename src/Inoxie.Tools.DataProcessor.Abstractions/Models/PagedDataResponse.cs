namespace Inoxie.Tools.DataProcessor.Abstractions.Models;

/// <summary>
/// Represents a paginated data response.
/// </summary>
/// <typeparam name="TData">The type of the data being paginated.</typeparam>
public class PagedDataResponse<TData>
    where TData : class
{
    public IEnumerable<TData> Collection { get; set; }
    public int Total { get; set; }
}
