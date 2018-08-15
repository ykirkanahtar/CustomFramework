using CustomFramework.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using CustomFramework.Data.Models;

namespace CustomFramework.Data.Repositories
{
    public class BaseRepositoryNonUser<TEntity, TKey> : AbstractRepository<TEntity, TKey>, IRepositoryNonUser<TEntity, TKey>
        where TEntity : BaseModelNonUser<TKey>

    {
        public BaseRepositoryNonUser(DbContext dbContext) : base(dbContext)
        {

        }

        public void Add(TEntity entity)
        {
            entity.CreateDateTime = DateTime.Now;
            entity.Status = Status.Active;
            DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            entity.UpdateDateTime = DateTime.Now;

            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            entity.DeleteDateTime = DateTime.Now;
            entity.Status = Status.Deleted;

            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}