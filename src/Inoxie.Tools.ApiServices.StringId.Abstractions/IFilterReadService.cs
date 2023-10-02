using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.ApiServices.StringId.Abstractions;

/// <summary>
/// Defines filtered read operations using a string identifier, with abilities for detailed querying and pagination.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseFilterReadService{TOutDto, TFilter, TId}"/> for scenarios where the identifier (`ID`) is a string. Implementations should facilitate filtering, pagination, and other querying abilities tailored for string-based identifiers. It takes advantage of the <see cref="BaseFilterModel"/> to determine the criteria for data retrieval and filtering.
/// </remarks>
public interface IFilterReadService<TOutDto, in TFilter> : IBaseFilterReadService<TOutDto, TFilter, string>, IReadService<TOutDto>
    where TOutDto : class
    where TFilter : BaseFilterModel
{
}