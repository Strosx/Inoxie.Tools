namespace Inoxie.Tools.DataProcessor.Abstractions.Models;

/// <summary>
/// Base model for pagination filters.
/// </summary>
public class BaseFilterModel
{
    public int Skip { get; set; }
    public int Take { get; set; }
}

/// <summary>
/// Extends the base filter model by adding search capabilities.
/// </summary>
public class BaseSearchableFilterModel : BaseFilterModel
{
    public string SearchValue { get; set; }
}
