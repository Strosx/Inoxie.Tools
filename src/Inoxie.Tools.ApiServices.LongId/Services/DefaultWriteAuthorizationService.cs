using Inoxie.Tools.ApiServices.LongId.Abstractions;
using Inoxie.Tools.ApiServices.Services;

namespace Inoxie.Tools.ApiServices.LongId.Services;

internal class DefaultWriteAuthorizationService<TInDto> : BaseDefaultWriteAuthorizationService<TInDto, long>, IWriteAuthorizationService<TInDto>
{
}