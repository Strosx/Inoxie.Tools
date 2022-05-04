using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.StringId.Abstractions;

public interface IWriteService<TInDto> : IBaseWriteService<TInDto, string>
{
}