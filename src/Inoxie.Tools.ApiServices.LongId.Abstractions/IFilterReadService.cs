using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.ApiServices.LongId.Abstractions;

/// <summary>
/// Defines filtered read operations using a long integer identifier, encompassing capabilities for specific querying and pagination.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseFilterReadService{TOutDto, TFilter, TId}"/> for cases where the identifier (`ID`) is a long integer. Implementations should offer filtering, pagination, and extended querying functions suitable for long integer identifiers. The <see cref="BaseFilterModel"/> is leveraged to set the parameters for data extraction and filtering.
/// </remarks>
public interface IFilterReadService<TOutDto, in TFilter> : IBaseFilterReadService<TOutDto, TFilter, long>, IReadService<TOutDto>
    where TOutDto : class
    where TFilter : BaseFilterModel
{}