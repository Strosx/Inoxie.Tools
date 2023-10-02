namespace Inoxie.Tools.Core.Repository.Abstractions;

/// <summary>
/// Represents a base entity interface that every database model must implement.
/// This interface ensures that each database model has a unique identifier represented by the 'Id' property.
/// </summary>
/// <typeparam name="TId">The type of the identifier (Id) which represents the primary key in the database.</typeparam>
public interface IBaseDataEntity<TId>
{
    /// <summary>
    /// Gets or sets the unique identifier for the database model, representing the primary key in the database.
    /// </summary>
    TId Id { get; set; }
}