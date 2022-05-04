namespace Inoxie.Tools.Core.Repository.Abstractions;

public interface IBaseDataEntity<TId>
{
    TId Id { get; set; }
}