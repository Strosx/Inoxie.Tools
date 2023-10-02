namespace Inoxie.Tools.DataProcessor.Abstractions.Models;

/// <summary>
/// Represents a paginated data response using IQueryable for more granular operations.
/// </summary>
/// <typeparam name="TData">The type of the data being paginated.</typeparam>
public class QueryablePagedDataResponse<TData>
    where TData : class
{
    public IQueryable<TData> Collection { get; set; }
    public int Total { get; set; }
}
