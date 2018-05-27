using System;
using CustomFramework.Data.ModelConfiguration;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.WebApiUtils.Authorization.Data.ModelConfigurations
{
    public class UserModelConfiguration<T> : BaseModelConfiguration<T, int> where T : User
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.EmailConfirmed)
                .IsRequired();

            builder.Property(p => p.EmailConfirmCode)
                .IsRequired()
                .HasMaxLength(6)
                .HasDefaultValue(new Random().Next(100000, 999999));

            builder.Property(p => p.AccessFailedCount)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.Lockout)
                .IsRequired();

            builder.Property(p => p.LockoutEndDateTime)
                .IsRequired(false)
                .HasMaxLength(256);

            builder.HasIndex(p => p.UserName);
            builder.HasIndex(p => p.Email);
            builder.HasIndex(p => new { p.UserName, p.Password });
        }
    }
}
