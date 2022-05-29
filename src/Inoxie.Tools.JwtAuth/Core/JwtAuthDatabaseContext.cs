using Inoxie.Tools.JwtAuth.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.JwtAuth.Core;

public abstract class JwtAuthDatabaseContext<TContext> : DbContext
    where TContext : DbContext
{
    public JwtAuthDatabaseContext(DbContextOptions<TContext> options)
    : base(options)
    { }

    public DbSet<AccountEntity> Accounts { get; set; }
    public DbSet<AccountRoleEntity> AccountRoles { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }
}
