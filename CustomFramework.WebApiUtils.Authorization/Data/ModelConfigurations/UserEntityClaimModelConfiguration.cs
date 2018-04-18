using System.Collections.Generic;
using CustomFramework.Data.ModelConfiguration;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.WebApiUtils.Authorization.Data.ModelConfigurations
{
    public class UserEntityClaimModelConfiguration<T> : BaseModelConfiguration<T, int> where T : UserEntityClaim
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

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
                .HasOne(r => r.User)
                .WithMany(c => (IEnumerable<T>)c.UserEntityClaims)
                .HasForeignKey(r => r.UserId);

        }
    }
}