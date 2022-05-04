using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.LongId.Abstractions;

public interface IWriteService<TInDto> : IWriteService<TInDto, long>
{
}