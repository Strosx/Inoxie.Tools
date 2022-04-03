using Inoxie.Tools.ApiServices.Attributes;
using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.ApiServices.Utilities;

internal static class UpdateMapperUtility
{
    public static TDb MapPropertiesFrom<TDb, TInDto>(this TDb entity, TInDto inDto)
        where TDb : IDataEntity
    {
        var inDtoProps = typeof(TInDto).GetProperties().Where(p => !Attribute.IsDefined(p, typeof(NoUpdateAttribute)));
        var dbProps = typeof(TDb).GetProperties();

        foreach (var inDtoProp in inDtoProps)
        {
            var dbPropToUpdate = dbProps.FirstOrDefault(f => f.Name == inDtoProp.Name);
            dbPropToUpdate.SetValue(entity, inDtoProp.GetValue(inDto));
        }

        return entity;
    }
}
