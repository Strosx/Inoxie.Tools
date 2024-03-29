﻿using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.ApiServices.StringId.Abstractions;

namespace Inoxie.Tools.ApiServices.StringId.Services;

internal class DefaultWriteAuthorizationService<TInDto> : BaseDefaultWriteAuthorizationService<TInDto, string>, IWriteAuthorizationService<TInDto>
{
}