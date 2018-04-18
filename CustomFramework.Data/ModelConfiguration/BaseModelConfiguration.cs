using System;
using CustomFramework.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.Data.ModelConfiguration
{
    public class BaseModelConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IBaseModel<TKey> where TKey : struct
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.Id);

            builder.Property(p => p.CreateDateTime)
                .IsRequired();

            builder.Property(p => p.UpdateDateTime);

            builder.Property(p => p.DeleteDateTime);

            builder.Property(p => p.Status)
                .IsRequired();
        }
    }
}