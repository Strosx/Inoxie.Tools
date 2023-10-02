using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;

namespace Inoxie.Tools.ApiServices.GuidId.Abstractions;

/// <summary>
/// Defines filtered read operations employing a GUID (Globally Unique Identifier) as an identifier, inclusive of specific querying and pagination facilities.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseFilterReadService{TOutDto, TFilter, TId}"/> for scenarios where the identifier (`ID`) is a GUID. Implementations should manage filtering, pagination, and additional querying procedures designed for GUID-based identifiers. The interface utilizes the <see cref="BaseFilterModel"/> to designate the guidelines for data collection and filtering.
/// </remarks>
public interface IFilterReadService<TOutDto, in TFilter> : IBaseFilterReadService<TOutDto, TFilter, Guid>, IReadService<TOutDto>
    where TOutDto : class
    where TFilter : BaseFilterModel
{
}