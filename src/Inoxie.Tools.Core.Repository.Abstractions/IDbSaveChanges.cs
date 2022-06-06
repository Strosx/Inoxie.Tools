using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Core.Repository.Abstractions;

public interface IDbSaveChanges
{
    Task SaveChangesAsync(Action<DbContext> action = null);
}