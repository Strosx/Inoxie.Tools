using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.Core.Repository.UpdateMappings
{
    internal class UpdateMapping<TEntity> : IUpdateMapping<TEntity>
    {
        public TEntity Map(TEntity databaseModel, TEntity newModel)
        {
            return databaseModel;
        }
    }
}
