using Inoxie.Tools.ApiServices.Utilities;
using Inoxie.Tools.Core.Repository.StringId.Abstractions;

namespace Inoxie.Tools.ApiServices.StringId.Utilities;

public static class UpdateMapperUtility
{
    public static TEntity MapPropertiesFrom<TEntity, TInDto>(this TEntity entity, TInDto inDto)
        where TEntity : IDataEntity
    {
        return entity.MapPropertiesFrom<TEntity, TInDto, string>(inDto);
    }
}