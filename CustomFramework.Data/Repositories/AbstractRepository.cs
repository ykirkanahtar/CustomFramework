using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Enums;
using CustomFramework.Data.Models;
using CustomFramework.Data.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CustomFramework.Data.Repositories
{
    public abstract class AbstractRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : BaseModelNonUser<TKey>
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;
        private bool _disposed;
        private readonly Expression<Func<TEntity, object>>[] _includeProperties = { };
        private readonly Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> _includes;

        protected AbstractRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        protected AbstractRepository(DbContext dbContext, Expression<Func<TEntity, object>>[] includeProperties)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
            _includeProperties = includeProperties;
        }

        protected AbstractRepository(DbContext dbContext, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
            _includes = includes;
        }

        protected AbstractRepository(DbContext dbContext, bool eager)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        #region IRepository members

        public async virtual Task<TEntity> GetByIdAsync(TKey id, bool selectPassives = false)
        {
            IQueryable<TEntity> query;
            if (selectPassives)
            {
                query = from p in DbContext.Set<TEntity>()
                        where p.Id.Equals(id) && (p.Status == Status.Active || p.Status == Status.Passive)
                        select p;
            }
            else
            {
                query = from p in DbContext.Set<TEntity>()
                        where p.Id.Equals(id) && p.Status == Status.Active
                        select p;
            }

            //var s = query.ToSql();

            if (_includes != null)
            {
                query = _includes(query);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual TEntity GetById(TKey id, bool selectPassives = false)
        {
            IQueryable<TEntity> query;
            if (selectPassives)
            {
                query = from p in DbContext.Set<TEntity>()
                        where p.Id.Equals(id) && (p.Status == Status.Active || p.Status == Status.Passive)
                        select p;
            }
            else
            {
                query = from p in DbContext.Set<TEntity>()
                        where p.Id.Equals(id) && p.Status == Status.Active
                        select p;
            }

            query = _includeProperties.Aggregate(query, (current, includedProperty) => current.Include(includedProperty));

            return query.FirstOrDefault();
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, bool selectPassives = false)
        {
            return DbSet.Where(PredicateBuild(predicate, selectPassives));
        }

        //OrderBy kullanımı örneği : GetAll(orderBy: q => q.OrderByDescending(s => s.CreateDateTime), take: 10)
        public virtual IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? take = null, bool selectPassives = false
        )
        {
            IQueryable<TEntity> query = DbSet;

            query = query.Where(predicate != null ? PredicateBuild(predicate, selectPassives) : PredicateBuild(selectPassives));
            query = _includeProperties.Aggregate(query, (current, includedProperty) => current.Include(includedProperty));

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

        public virtual async Task<ICustomQueryable<TEntity>> GetAllWithPagingAsync(
            IPaging paging, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool selectPassives = false
        )
        {
            IQueryable<TEntity> query = DbSet;

            query = query.Where(predicate != null ? PredicateBuild(predicate, selectPassives) : PredicateBuild(selectPassives));

            var rowCount = await query.CountAsync();
            query = _includeProperties.Aggregate(query, (current, includedProperty) => current.Include(includedProperty));

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            query = query.Skip(Math.Abs(paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);

            var pageCount = (rowCount + paging.PageSize - 1) / paging.PageSize;

            return new CustomQueryable<TEntity>
            {
                Result = query,
                TotalCount = rowCount,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                PageCount = pageCount
            };
        }

        public virtual ICustomQueryable<TEntity> GetAllWithPaging(
            IPaging paging, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool selectPassives = false
        )
        {
            IQueryable<TEntity> query = DbSet;

            query = query.Where(predicate != null ? PredicateBuild(predicate, selectPassives) : PredicateBuild(selectPassives));

            var rowCount = query.Count();
            query = _includeProperties.Aggregate(query, (current, includedProperty) => current.Include(includedProperty));

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            query = query.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);

            var pageCount = (rowCount + paging.PageSize - 1) / paging.PageSize;

            return new CustomQueryable<TEntity>
            {
                Result = query,
                TotalCount = rowCount,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                PageCount = pageCount
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

        private static Expression<Func<TEntity, bool>> PredicateBuild(Expression<Func<TEntity, bool>> predicate, bool selectPassives = false)
        {
            if (selectPassives) return predicate.And(p => (int)p.Status == (int)Status.Active || (int)p.Status == (int)Status.Passive);
            return predicate.And(p => (int)p.Status == (int)Status.Active);
        }

        private static Expression<Func<TEntity, bool>> PredicateBuild(bool selectPassives = false)
        {
            var predicate = PredicateBuilder.New<TEntity>();

            if (selectPassives) return predicate.And(p => (int)p.Status == (int)Status.Active || (int)p.Status == (int)Status.Passive);
            return predicate.And(p => (int)p.Status == (int)Status.Active);
        }

        #endregion
    }
}