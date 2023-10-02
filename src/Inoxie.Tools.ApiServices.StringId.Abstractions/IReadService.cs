using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.StringId.Abstractions;

/// <summary>
/// Defines basic read operations for DTOs using a string as an identifier.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseReadService{TOutDto, TId}"/> for use cases where the identifier (`ID`) is a string. Implementations should ensure that data retrieval and authorization checks are tailored for string-based identifiers. Like its base interface, the services should leverage the associated repository and authorization services.
/// </remarks>
public interface IReadService<TOutDto> : IBaseReadService<TOutDto, string>
{
}