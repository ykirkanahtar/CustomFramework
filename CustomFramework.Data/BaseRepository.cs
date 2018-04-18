using System;
using System.Linq;
using System.Linq.Expressions;
using CustomFramework.Data.Enums;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CustomFramework.Data
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity>, IDisposable
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

        public IQueryable<TEntity> GetAll(
             Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , ISkipTake skipTake = null
        )
        {
            return GetAll(false, out var _, predicate, orderBy, include, skipTake);
        }

        public IQueryable<TEntity> GetAll(out int rowCount
                                                        , Expression<Func<TEntity, bool>> predicate = null
                                                        , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
                                                        , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
                                                        , ISkipTake skipTake = null
                                                        )
        {
            return GetAll(true, out rowCount, predicate, orderBy, include, skipTake);
        }

        private IQueryable<TEntity> GetAll(bool calculateRowCount
                , out int rowCount
                , Expression<Func<TEntity, bool>> predicate = null
                , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
                , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
                , ISkipTake skipTake = null
        )
        {
            IQueryable<TEntity> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            query = query.Where(predicate != null ? PredicateBuild(predicate) : PredicateBuild());

            rowCount = 0;
            if (calculateRowCount) rowCount = query.Count();

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skipTake != null)
                query = query.Skip(skipTake.Skip).Take(skipTake.Take);

            return query;
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

        protected void Dispose(bool disposing)
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