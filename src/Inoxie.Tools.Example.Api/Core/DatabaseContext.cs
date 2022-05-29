using Inoxie.Tools.JwtAuth.Core;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Example.Api.Core;

public class DatabaseContext : JwtAuthDatabaseContext<DatabaseContext>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}


