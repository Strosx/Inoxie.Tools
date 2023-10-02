using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.LongId.Abstractions;

/// <summary>
/// Defines basic write operations for a given DTO with a long identifier.
/// </summary>
/// <remarks>
/// This interface specializes the <see cref="IBaseWriteService{TInDto, TId}"/> for use cases where the identifier (`ID`) is a long. By extending the IBaseWriteService with a long ID, it simplifies the consumption for services and repositories that inherently deal with long-based identifiers.
/// The underlying implementation ensures that all basic write operations such as creation, deletion, and updating of records are appropriately handled for long IDs.
/// </remarks>
public interface IWriteService<TInDto> : IBaseWriteService<TInDto, long>
{
}