﻿using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.StringId.Abstractions;

public interface IReadService<TOutDto> : IReadService<TOutDto, string>
{
}