using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.GuidId.Abstractions;

public interface IWriteAuthorizationService<TInDto> : IWriteAuthorizationService<TInDto, Guid>
{
}