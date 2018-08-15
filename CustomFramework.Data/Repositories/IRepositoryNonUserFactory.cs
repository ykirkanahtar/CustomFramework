using CustomFramework.Data.Models;

namespace CustomFramework.Data.Repositories
{
    public interface IRepositoryNonUserFactory
    {
        IRepositoryNonUser<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseModelNonUser<TKey>;
    }
}