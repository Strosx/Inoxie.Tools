using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Core.Repository.Implementations
{
    internal class DatabaseContextProvider<TContext> : IDatabaseContextProvider
        where TContext : DbContext
    {
        private readonly TContext context;

        public DatabaseContextProvider(TContext context)
        {
            this.context = context;
        }
        public DbContext Get()
        {
            return context;
        }
    }
}
