using Inoxie.Tools.ApiServices.Utilities;
using Inoxie.Tools.Core.Repository.LongId.Abstractions;

namespace Inoxie.Tools.ApiServices.LongId.Utilities;

public static class UpdateMapperUtility
{
    public static TEntity MapPropertiesFrom<TEntity, TInDto>(this TEntity entity, TInDto inDto)
        where TEntity : IDataEntity
    {
        return entity.MapPropertiesFrom<TEntity, TInDto, long>(inDto);
    }
}