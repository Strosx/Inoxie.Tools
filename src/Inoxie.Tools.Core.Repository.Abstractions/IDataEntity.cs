namespace Inoxie.Tools.Core.Repository.Abstractions;

public interface IDataEntity<TId>
{
    TId Id { get; set; }
}