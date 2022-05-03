using Inoxie.Tools.ApiServices.GuidId.Abstractions;
using Inoxie.Tools.ApiServices.Services;

namespace Inoxie.Tools.ApiServices.GuidId.Services;

internal class DefaultWriteAuthorizationService<TInDto> : DefaultWriteAuthorizationService<TInDto, Guid>, IWriteAuthorizationService<TInDto>
{
}