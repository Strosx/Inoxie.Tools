using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Core.Repository.Repositories;

public class DbSaveChanges : IDbSaveChanges
{
    private readonly DbContext context;

    public async Task SaveChangesAsync(List<object> modifiedEntities = null)
    {
        modifiedEntities?.ForEach(entity => context.Entry(entity).State = EntityState.Modified);
        await context.SaveChangesAsync();
    }
}