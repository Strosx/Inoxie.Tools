using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.GuidId.Abstractions;

/// <summary>
/// Defines basic read operations for DTOs using a GUID (Globally Unique Identifier) as an identifier.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseReadService{TOutDto, TId}"/> for scenarios where the identifier (`ID`) is a GUID. Implementations should ensure that data retrieval and authorization checks are specifically tailored for GUID-based identifiers. As with its base interface, the services should make use of the associated repository and authorization services.
/// </remarks>
public interface IReadService<TOutDto> : IBaseReadService<TOutDto, Guid>
{}