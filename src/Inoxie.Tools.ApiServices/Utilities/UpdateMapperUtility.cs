using Inoxie.Tools.ApiServices.Attributes;
using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.ApiServices.Utilities;

internal static class UpdateMapperUtility
{
    internal static TEntity MapPropertiesFrom<TEntity, TInDto, TId>(this TEntity entity, TInDto inDto)
        where TEntity : IBaseDataEntity<TId>
    {
        var inDtoProps = typeof(TInDto).GetProperties().Where(p => !Attribute.IsDefined(p, typeof(NoUpdateAttribute)));
        var dbProps = typeof(TEntity).GetProperties();

        foreach (var inDtoProp in inDtoProps)
        {
            var dbPropToUpdate = dbProps.FirstOrDefault(f => f.Name == inDtoProp.Name);
            if (dbPropToUpdate == null) continue;

            dbPropToUpdate.SetValue(entity, inDtoProp.GetValue(inDto));
        }

        return entity;
    }
}