namespace Inoxie.Tools.Core.Repository.Abstractions;

public interface IDbSaveChanges
{
    Task SaveChangesAsync(List<object> modifiedEntities = null);
    Task SaveChangesAsync(object modifiedEntity = null);
}