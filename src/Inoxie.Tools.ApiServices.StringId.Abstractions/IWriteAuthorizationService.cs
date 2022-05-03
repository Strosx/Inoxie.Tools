using Inoxie.Tools.ApiServices.Abstractions.Interfaces;

namespace Inoxie.Tools.ApiServices.StringId.Abstractions;

public interface IWriteAuthorizationService<TInDto> : IWriteAuthorizationService<TInDto, string>
{
}