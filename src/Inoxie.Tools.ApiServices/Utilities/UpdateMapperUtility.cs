using Inoxie.Tools.ApiServices.Attributes;
using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.ApiServices.Utilities;

public static class UpdateMapperUtility
{
    /// <summary>
    /// Maps properties from the provided DTO to the given entity, excluding properties marked with the <see cref="NoUpdateAttribute"/>.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity.</typeparam>
    /// <typeparam name="TInDto">Type of the input DTO.</typeparam>
    /// <typeparam name="TId">Type of the identifier.</typeparam>
    /// <param name="entity">The entity to update.</param>
    /// <param name="inDto">The DTO containing the new values.</param>
    /// <returns>The updated entity.</returns>
    /// <remarks>
    /// The method works by iterating over properties of the DTO and mapping their values to the corresponding properties of the entity. 
    /// If a property in the DTO is marked with the <see cref="NoUpdateAttribute"/>, it will be skipped, ensuring that the value of that property on the entity remains unchanged.
    /// Matching between DTO and entity properties is done based on property names. If a property exists in the DTO but not in the entity (or vice versa), it's ignored.
    /// </remarks>
    public static TEntity MapPropertiesFrom<TEntity, TInDto, TId>(this TEntity entity, TInDto inDto)
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