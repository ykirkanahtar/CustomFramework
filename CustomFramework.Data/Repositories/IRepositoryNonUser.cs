using CustomFramework.Data.Models;

namespace CustomFramework.Data.Repositories
{
    public interface IRepositoryNonUser<TEntity, in TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : BaseModelNonUser<TKey>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}