﻿using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.LongId.Abstractions;

public interface IWriteAuthorizationService<TInDto> : IWriteAuthorizationService<TInDto, long>
{
}