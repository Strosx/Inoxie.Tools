using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.StringId.Abstractions;

/// <summary>
/// Defines methods for write authorization using string as an identifier.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseWriteAuthorizationService{TInDto, TId}"/> for use cases where the identifier (`ID`) is a string. Implementations should ensure that authorization checks are tailored for string-based identifiers. Like its base interface, the implementing classes should focus solely on authorization logic.
/// </remarks>
public interface IWriteAuthorizationService<TInDto> : IBaseWriteAuthorizationService<TInDto, string>
{
}