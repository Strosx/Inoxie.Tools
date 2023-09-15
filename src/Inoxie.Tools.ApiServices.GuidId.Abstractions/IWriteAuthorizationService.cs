using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.GuidId.Abstractions;

/// <summary>
/// Defines methods for write authorization using a GUID (Globally Unique Identifier) as an identifier.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseWriteAuthorizationService{TInDto, TId}"/> for scenarios where the identifier (`ID`) is a GUID. Implementations should ensure that authorization checks are specifically tailored for GUID-based identifiers. Like its base interface, the focus should be solely on authorization logic.
/// </remarks>
public interface IWriteAuthorizationService<TInDto> : IBaseWriteAuthorizationService<TInDto, Guid>
{
}