using Inoxie.Tools.ApiServices.Utilities;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;

namespace Inoxie.Tools.ApiServices.GuidId.Utilities;

public static class UpdateMapperUtility
{
    /// <summary>
    /// Maps properties from the provided DTO to the given entity, excluding properties marked with the <see cref="Inoxie.Tools.ApiServices.Attributes.NoUpdateAttribute"/>.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity.</typeparam>
    /// <typeparam name="TInDto">Type of the input DTO.</typeparam>
    /// <param name="entity">The entity to update.</param>
    /// <param name="inDto">The DTO containing the new values.</param>
    /// <returns>The updated entity with a GUID identifier.</returns>
    /// <remarks>
    /// This method wraps the core utility method from <see cref="Inoxie.Tools.ApiServices.Utilities.UpdateMapperUtility"/> 
    /// and is specialized for entities with GUID identifiers.
    /// </remarks>
    public static TEntity MapPropertiesFrom<TEntity, TInDto>(this TEntity entity, TInDto inDto)
        where TEntity : IDataEntity
    {
        return entity.MapPropertiesFrom<TEntity, TInDto, Guid>(inDto);
    }
}