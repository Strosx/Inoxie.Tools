using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.LongId.Abstractions;

/// <summary>
/// Defines basic read operations for DTOs using a long integer as an identifier.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseReadService{TOutDto, TId}"/> for scenarios where the identifier (`ID`) is a long integer. Implementations should ensure that data retrieval and authorization checks are tailored for long integer identifiers. Like its base interface, the services should leverage the related repository and authorization services.
/// </remarks>
public interface IReadService<TOutDto> : IBaseReadService<TOutDto, long>
{
}