using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.Implementations;
using Inoxie.Tools.Core.Repository.Repositories;
using Inoxie.Tools.Core.Repository.UpdateMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.Core.Repository.DI
{
    internal static class RepositoryDependencyInjection
    {
        public static void Configure<TDatabaseContext>(IServiceCollection services)
                        where TDatabaseContext : DbContext
        {
            services.AddTransient(typeof(IReadRepository<>), typeof(BaseReadRepository<>));
            services.AddTransient(typeof(IWriteRepository<>), typeof(BaseWriteRepository<>));
            services.AddTransient(typeof(IUpdateMapping<>), typeof(UpdateMapping<>));
            services.AddTransient<IDatabaseContextProvider, DatabaseContextProvider<TDatabaseContext>>();
        }
    }

    public static class InoxieToolsRepositoryExtensions
    {
        public static void AddInoxieRepository<TDatabaseContext>(IServiceCollection services)
            where TDatabaseContext : DbContext
        {
            RepositoryDependencyInjection.Configure<TDatabaseContext>(services);
        }
    }
}
