using Inoxie.Tools.ApiServices.LongId.Abstractions;
using Inoxie.Tools.ApiServices.Services;

namespace Inoxie.Tools.ApiServices.LongId.Services;

internal class DefaultWriteAuthorizationService<TInDto> : DefaultWriteAuthorizationService<TInDto, long>, IWriteAuthorizationService<TInDto>
{
}