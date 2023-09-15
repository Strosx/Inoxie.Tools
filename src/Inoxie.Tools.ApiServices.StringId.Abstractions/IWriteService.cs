using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.StringId.Abstractions;

/// <summary>
/// Defines basic write operations for a given DTO with a string identifier.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseWriteService{TInDto, TId}"/> for use cases where the identifier (`ID`) is a string. By extending the IBaseWriteService with a string ID, it simplifies the consumption for services and repositories that inherently deal with string-based identifiers.
/// The underlying implementation ensures that all basic write operations such as creation, deletion, and updating of records are appropriately handled for string IDs.
/// </remarks>
public interface IWriteService<TInDto> : IBaseWriteService<TInDto, string>
{
}