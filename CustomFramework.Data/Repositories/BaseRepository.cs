using CustomFramework.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using CustomFramework.Data.Models;

namespace CustomFramework.Data.Repositories
{
    public class BaseRepository<TEntity, TKey> : AbstractRepository<TEntity, TKey>, IRepository<TEntity, TKey>
        where TEntity : BaseModel<TKey>

    {
        public BaseRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public BaseRepository(DbContext dbContext, Expression<Func<TEntity, object>>[] includeProperties) : base(dbContext, includeProperties)
        {

        }

        public void Add(TEntity entity, int userId)
        {
            entity.CreateDateTime = DateTime.Now;
            entity.CreateUserId = userId;
            entity.Status = Status.Active;
            DbSet.Add(entity);
        }

        public void Update(TEntity entity, int userId)
        {
            entity.UpdateDateTime = DateTime.Now;
            entity.UpdateUserId = userId;

            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity, int userId)
        {
            entity.DeleteDateTime = DateTime.Now;
            entity.DeleteUserId = userId;
            entity.Status = Status.Deleted;

            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}