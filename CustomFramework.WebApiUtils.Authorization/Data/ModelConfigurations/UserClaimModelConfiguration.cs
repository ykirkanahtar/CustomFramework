using System.Collections.Generic;
using CustomFramework.Data.ModelConfiguration;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.WebApiUtils.Authorization.Data.ModelConfigurations
{
    public class UserClaimModelConfiguration<T> : BaseModelConfiguration<T, int> where T : UserClaim
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.ApplicationId)
                .IsRequired();

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.ClaimId)
                .IsRequired();

            builder
                .HasOne(r => r.Application)
                .WithMany(c => (IEnumerable<T>)c.UserClaims)
                .HasForeignKey(r => r.ApplicationId)
                .HasPrincipalKey(c => c.Id);

            builder
                 .HasOne(r => r.User)
                 .WithMany(c => (IEnumerable<T>)c.UserClaims)
                 .HasForeignKey(r => r.UserId);

            builder
                .HasOne(r => r.Claim)
                .WithMany(c => (IEnumerable<T>)c.UserClaims)
                .HasForeignKey(r => r.ClaimId);

            builder.HasIndex(p => new { p.ApplicationId, p.UserId, p.ClaimId });

        }
    }
}