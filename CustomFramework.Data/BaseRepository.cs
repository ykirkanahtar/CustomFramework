using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Enums;
using CustomFramework.Data.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CustomFramework.Data
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
           where TEntity : BaseModel<TKey>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        private bool _disposed;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        #region IRepository members

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public TEntity GetById(TKey id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(PredicateBuild(predicate));
        }

        public IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        )
        {
            IQueryable<TEntity> query = _dbSet;

            query = query.Where(predicate != null ? PredicateBuild(predicate) : PredicateBuild());

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        public async Task<ICustomQueryable<TEntity>> GetAllWithPagingAsync(
            IPaging paging
            , Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        )
        {
            IQueryable<TEntity> query = _dbSet;

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
            IQueryable<TEntity> query = _dbSet;

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

        public void Add(TEntity entity)
        {
            entity.CreateDateTime = DateTime.Now;
            entity.Status = Status.Active;
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            entity.UpdateDateTime = DateTime.Now;

            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            entity.DeleteDateTime = DateTime.Now;
            entity.Status = Status.Deleted;

            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        #endregion

        #region IDisposable members
        ~BaseRepository()
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
                _dbContext.Dispose();
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