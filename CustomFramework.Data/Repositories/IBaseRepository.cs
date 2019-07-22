using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace CustomFramework.Data.Repositories
{
    public interface IBaseRepository<TEntity, in TKey> : IDisposable
    where TEntity : BaseModelNonUser<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id, bool selectPassives = false);

        TEntity GetById(TKey id, bool selectPassives = false);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, bool selectPassives = false);

        IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? take = null, bool selectPassives = false
        );

        Task<ICustomQueryable<TEntity>> GetAllWithPagingAsync(
            IPaging paging
            , Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null
            , bool selectPassives = false
        );

        ICustomQueryable<TEntity> GetAllWithPaging(
            IPaging paging, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool selectPassives = false
        );
    }
}