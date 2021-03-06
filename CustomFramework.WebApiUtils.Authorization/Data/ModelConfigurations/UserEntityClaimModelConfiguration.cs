﻿using System.Collections.Generic;
using CustomFramework.Data.ModelConfiguration;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.WebApiUtils.Authorization.Data.ModelConfigurations
{
    public class UserEntityClaimModelConfiguration<T> : BaseModelNonUserConfiguration<T, int> where T : UserEntityClaim
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.ApplicationId)
                .IsRequired();

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.Entity)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.CanSelect)
                .IsRequired();

            builder.Property(p => p.CanCreate)
                .IsRequired();

            builder.Property(p => p.CanUpdate)
                .IsRequired();

            builder.Property(p => p.CanDelete)
                .IsRequired();

            builder
                .HasOne(r => r.Application)
                .WithMany(c => (IEnumerable<T>)c.UserEntityClaims)
                .HasForeignKey(r => r.ApplicationId)
                .HasPrincipalKey(c => c.Id);

            builder
                .HasOne(r => r.User)
                .WithMany(c => (IEnumerable<T>)c.UserEntityClaims)
                .HasForeignKey(r => r.UserId);

            builder.HasIndex(p => new { p.ApplicationId, p.UserId, p.Entity, p.CanSelect });
            builder.HasIndex(p => new { p.ApplicationId, p.UserId, p.Entity, p.CanCreate });
            builder.HasIndex(p => new { p.ApplicationId, p.UserId, p.Entity, p.CanUpdate });
            builder.HasIndex(p => new { p.ApplicationId, p.UserId, p.Entity, p.CanDelete });
        }
    }
}