using System.Collections.Generic;
using CustomFramework.Data.ModelConfiguration;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.WebApiUtils.Authorization.Data.ModelConfigurations
{
    public class UserRoleModelConfiguration<T> : BaseModelConfiguration<T, int> where T : UserRole
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.RoleId)
                .IsRequired();

            builder
                .HasOne(r => r.User)
                .WithMany(c => (IEnumerable<T>)c.UserRoles)
                .HasForeignKey(r => r.UserId);

            builder
                .HasOne(r => r.Role)
                .WithMany(c => (IEnumerable<T>)c.UserRoles)
                .HasForeignKey(r => r.RoleId);

            builder.HasIndex(p => new { p.UserId, p.Status });
        }
    }
}