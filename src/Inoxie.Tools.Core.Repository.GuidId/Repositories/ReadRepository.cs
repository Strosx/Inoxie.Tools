﻿using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.Core.Repository.GuidId.Abstractions;
using Inoxie.Tools.Core.Repository.Repositories;

namespace Inoxie.Tools.Core.Repository.GuidId.Repositories;

public class ReadRepository<TEntity> : ReadRepository<TEntity, Guid>, IReadRepository<TEntity>
    where TEntity : class, IDataEntity<Guid>
{
    public ReadRepository(IDatabaseContextProvider databaseContextProvider) : base(databaseContextProvider)
    {
    }
}