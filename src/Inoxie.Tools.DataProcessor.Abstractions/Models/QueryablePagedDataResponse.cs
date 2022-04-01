namespace Inoxie.Tools.DataProcessor.Abstractions.Models
{
    public class QueryablePagedDataResponse<TData>
        where TData : class
    {
        public IQueryable<TData> Collection { get; set; }
        public int Total { get; set; }
    }
}
