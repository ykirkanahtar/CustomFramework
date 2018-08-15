using CustomFramework.Data.Models;

namespace CustomFramework.Data.Repositories
{
    public interface IRepository<TEntity, in TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : BaseModel<TKey>
    {
        void Add(TEntity entity, int userId);
        void Update(TEntity entity, int userId);
        void Delete(TEntity entity, int userId);
    }
}