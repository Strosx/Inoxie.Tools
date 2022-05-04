using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.GuidId.Abstractions;

public interface IWriteService<TInDto> : IBaseWriteService<TInDto, Guid>
{}
