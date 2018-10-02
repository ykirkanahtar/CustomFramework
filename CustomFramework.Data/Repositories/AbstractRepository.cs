using CustomFramework.Data.Contracts;
using CustomFramework.Data.Enums;
using CustomFramework.Data.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustomFramework.Data.Repositories
{
    public abstract class AbstractRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
           where TEntity : BaseModelNonUser<TKey>
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;
        private bool _disposed;

        protected AbstractRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        #region IRepository members

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            var entity = await DbContext.Set<TEntity>().FindAsync(id);
            return entity?.Status == Status.Active ? entity : null;
        }

        public TEntity GetById(TKey id)
        {
            var entity = DbContext.Set<TEntity>().Find(id);
            return entity?.Status == Status.Active ? entity : null;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(PredicateBuild(predicate));
        }


        //OrderBy kullanımı örneği : GetAll(orderBy: q => q.OrderByDescending(s => s.CreateDateTime), take: 10)
        public IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , int? take = null
        )
        {
            IQueryable<TEntity> query = DbSet;

            query = query.Where(predicate != null ? PredicateBuild(predicate) : PredicateBuild());

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (take != null)
            {
                query = query.Take((int)take);
            }

            return query;
        }

        public async Task<ICustomQueryable<TEntity>> GetAllWithPagingAsync(
            IPaging paging
            , Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        )
        {
            IQueryable<TEntity> query = DbSet;

            query = query.Where(predicate != null ? PredicateBuild(predicate) : PredicateBuild());

            var rowCount = await query.CountAsync();

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            query = query.Skip(Math.Abs(paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);

            return new CustomQueryable<TEntity>
            {
                Result = query,
                Count = rowCount,
            };
        }

        public ICustomQueryable<TEntity> GetAllWithPaging(
            IPaging paging
            , Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        )
        {
            IQueryable<TEntity> query = DbSet;

            query = query.Where(predicate != null ? PredicateBuild(predicate) : PredicateBuild());

            var rowCount = query.Count();

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            query = query.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);

            return new CustomQueryable<TEntity>
            {
                Result = query,
                Count = rowCount,
            };
        }

        #endregion

        #region IDisposable members
        ~AbstractRepository()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                DbContext.Dispose();
            }

            _disposed = true;
        }

        private static Expression<Func<TEntity, bool>> PredicateBuild(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate.And(p => (int)p.Status == (int)Status.Active);
        }

        private static Expression<Func<TEntity, bool>> PredicateBuild()
        {
            var predicate = PredicateBuilder.New<TEntity>();
            return predicate.And(p => (int)p.Status == (int)Status.Active);
        }

        #endregion
    }
}