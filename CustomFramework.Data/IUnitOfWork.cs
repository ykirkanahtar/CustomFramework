using System;
using System.Linq;
using System.Threading.Tasks;
using CustomFramework.Data.Models;
using CustomFramework.Data.Repositories;

namespace CustomFramework.Data
{
    public interface IUnitOfWork : IDisposable
    {
        BaseRepository<TEntity,TKey> GetRepository<TEntity, TKey>() where TEntity : BaseModel<TKey>;

        BaseRepositoryNonUser<TEntity, TKey> GetRepositoryNonUser<TEntity, TKey>() where TEntity : BaseModelNonUser<TKey>;
        
        int SaveChanges();

        Task<int> SaveChangesAsync();

        int ExecuteSqlCommand(string sql, params object[] parameters);

        IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class;
    }
}