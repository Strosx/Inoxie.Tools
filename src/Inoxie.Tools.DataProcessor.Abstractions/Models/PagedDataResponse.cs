namespace Inoxie.Tools.DataProcessor.Abstractions.Models;

public class PagedDataResponse<TData>
    where TData : class
{
    public IEnumerable<TData> Collection { get; set; }
    public int Total { get; set; }
}
