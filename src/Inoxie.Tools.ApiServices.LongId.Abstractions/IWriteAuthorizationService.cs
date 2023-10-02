using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.LongId.Abstractions;

/// <summary>
/// Defines methods for write authorization using a long integer as an identifier.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseWriteAuthorizationService{TInDto, TId}"/> for scenarios where the identifier (`ID`) is a long integer. Implementations should ensure that authorization checks are tailored for long integer identifiers. Like its base interface, the focus should be exclusively on authorization logic.
/// </remarks>
public interface IWriteAuthorizationService<TInDto> : IBaseWriteAuthorizationService<TInDto, long>
{
}