namespace Inoxie.Tools.Core.Repository.Abstractions
{
    public interface IUpdateMapping<TEntity>
    {
        TEntity Map(TEntity databaseModel, TEntity newModel);
    }
}
