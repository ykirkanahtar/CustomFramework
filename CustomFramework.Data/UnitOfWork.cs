using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomFramework.Data.Models;
using CustomFramework.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

//https://github.com/Arch/UnitOfWork/blob/master/src/Microsoft.EntityFrameworkCore.UnitOfWork/UnitOfWork.cs
namespace CustomFramework.Data
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext> where TContext : DbContext
    {
        private bool _disposed;
        private Dictionary<Type, object> _repositories;

        protected UnitOfWork(TContext context)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TContext DbContext { get; }

        public BaseRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseModel<TKey>
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new BaseRepository<TEntity, TKey>(DbContext);
            }

            return (BaseRepository<TEntity, TKey>)_repositories[type];
        }

        public BaseRepositoryNonUser<TEntity, TKey> GetRepositoryNonUser<TEntity, TKey>() where TEntity : BaseModelNonUser<TKey>
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new BaseRepositoryNonUser<TEntity, TKey>(DbContext);
            }

            return (BaseRepositoryNonUser<TEntity, TKey>)_repositories[type];
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters) => DbContext.Database.ExecuteSqlCommand(sql, parameters);

        public IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class => DbContext.Set<TEntity>().FromSql(sql, parameters);

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(params IUnitOfWork[] unitOfWorks)
        {
            // TransactionScope will be included in .NET Core v2.0
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    var count = 0;
                    foreach (var unitOfWork in unitOfWorks)
                    {
                        if (!(unitOfWork is UnitOfWork<DbContext> uow)) continue;
                        uow.DbContext.Database.UseTransaction(transaction.GetDbTransaction());
                        count += await uow.SaveChangesAsync();
                    }

                    count += await SaveChangesAsync();

                    transaction.Commit();

                    return count;
                }
                catch (Exception)
                {

                    transaction.Rollback();

                    throw;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                // clear repositories
                _repositories?.Clear();

                // dispose the db context.
                DbContext.Dispose();
            }

            _disposed = true;
        }
    }

}