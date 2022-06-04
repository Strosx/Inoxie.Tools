using System.Collections;
using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Core.Repository.Repositories;

public class DbSaveChanges : IDbSaveChanges
{
    private readonly DbContext context;

    public DbSaveChanges(DbContext context)
    {
        this.context = context;
    }

    public async Task SaveChangesAsync(object modifiedEntity = null)
    {
        if (modifiedEntity != null)
        {
            context.Entry(modifiedEntity).State = EntityState.Modified;
        }

        await context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync<TEntity>(List<TEntity> modifiedEntities)
        where TEntity : class
    {
        modifiedEntities.ForEach(entity => context.Entry(entity).State = EntityState.Modified);
        await context.SaveChangesAsync();
    }
}