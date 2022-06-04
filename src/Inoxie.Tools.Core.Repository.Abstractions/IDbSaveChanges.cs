namespace Inoxie.Tools.Core.Repository.Abstractions;

public interface IDbSaveChanges
{
    Task SaveChangesAsync(object modifiedEntity = null);

    Task SaveChangesAsync<TEntity>(List<TEntity> modifiedEntities)
        where TEntity : class;
}