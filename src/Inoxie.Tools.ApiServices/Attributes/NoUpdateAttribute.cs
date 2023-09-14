namespace Inoxie.Tools.ApiServices.Attributes;

/// <summary>
/// Indicates that the property should not be updated by the <see cref="UpdateMapperUtility.MapPropertiesFrom{TEntity, TInDto, TId}(TEntity, TInDto)"/> method.
/// </summary>
/// <remarks>
/// This attribute is specifically tailored to exclude properties from update operations performed by the aforementioned method.
/// Applying it ensures that the property will remain unchanged during the mapping process. It does not have any effect on other operations or methods.
/// </remarks>
[AttributeUsage(AttributeTargets.Property)]
public class NoUpdateAttribute : Attribute
{}
