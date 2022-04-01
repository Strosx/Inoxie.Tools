namespace Inoxie.Tools.DataProcessor.Abstractions.Models
{
    public class BaseFilterModel
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }

    public class BaseSearchableFilterModel : BaseFilterModel
    {
        public string SearchValue { get; set; }
    }
}
