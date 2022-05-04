using Inoxie.Tools.ApiServices.Utilities;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;

namespace Inoxie.Tools.ApiServices.GuidId.Utilities;

internal static class UpdateMapperUtility
{
    public static TEntity MapPropertiesFrom<TEntity, TInDto>(this TEntity entity, TInDto inDto)
        where TEntity : IDataEntity
    {
        return entity.MapPropertiesFrom<TEntity, TInDto, Guid>(inDto);
    }
}