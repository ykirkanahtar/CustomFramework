using System.Collections.Generic;
using CustomFramework.Data.ModelConfiguration;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.WebApiUtils.Authorization.Data.ModelConfigurations
{
    public class ApplicationUserModelConfiguration<T> : BaseModelNonUserConfiguration<T, int> where T : ApplicationUser
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.ApplicationId)
                .IsRequired();

            builder
                .HasOne(r => r.User)
                .WithMany(c => (IEnumerable<T>)c.ApplicationUsers)
                .HasForeignKey(r => r.UserId);

            builder
                .HasOne(r => r.Application)
                .WithMany(c => (IEnumerable<T>)c.ApplicationUsers)
                .HasForeignKey(r => r.ApplicationId);

            builder.HasIndex(p => new { p.UserId, p.Status });
            builder.HasIndex(p => new { p.ApplicationId, p.Status });

        }
    }
}