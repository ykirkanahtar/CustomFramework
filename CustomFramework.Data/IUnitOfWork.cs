using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomFramework.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity,TKey> GetRepository<TEntity, TKey>() where TEntity : BaseModel<TKey>;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        int ExecuteSqlCommand(string sql, params object[] parameters);

        IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class;
    }

}