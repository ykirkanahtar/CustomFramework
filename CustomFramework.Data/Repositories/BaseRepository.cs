using CustomFramework.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using CustomFramework.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using CustomFramework.Data.Contracts;

namespace CustomFramework.Data.Repositories
{
    public class BaseRepository<TEntity, TKey> : AbstractRepository<TEntity, TKey>, IRepository<TEntity, TKey>
        where TEntity : BaseModel<TKey>

    {
        public BaseRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public BaseRepository(DbContext dbContext, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes) : base(dbContext, includes)
        {

        }

        public virtual void Add(TEntity entity, int userId, DateTime? logDateTime = null)
        {
            entity.CreateDateTime = logDateTime != null ? (DateTime)logDateTime : DateTime.UtcNow;
            entity.CreateUserId = userId;
            entity.Status = Status.Active;
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity, int userId, DateTime? logDateTime = null)
        {
            entity.UpdateDateTime = logDateTime != null ? (DateTime)logDateTime : DateTime.UtcNow;
            entity.UpdateUserId = userId;

            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity, int userId, DateTime? logDateTime = null)
        {
            entity.DeleteDateTime = logDateTime != null ? (DateTime)logDateTime : DateTime.UtcNow;
            entity.DeleteUserId = userId;
            entity.Status = Status.Deleted;

            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}