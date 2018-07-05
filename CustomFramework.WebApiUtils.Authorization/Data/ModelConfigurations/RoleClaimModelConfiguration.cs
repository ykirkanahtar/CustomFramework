using System.Collections.Generic;
using CustomFramework.Data.ModelConfiguration;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.WebApiUtils.Authorization.Data.ModelConfigurations
{
    public class RoleClaimModelConfiguration<T> : BaseModelConfiguration<T, int> where T : RoleClaim
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.ApplicationId)
                .IsRequired();

            builder.Property(p => p.RoleId)
                .IsRequired();

            builder.Property(p => p.ClaimId)
                .IsRequired();

            builder
                .HasOne(r => r.Application)
                .WithMany(c => (IEnumerable<T>)c.RoleClaims)
                .HasForeignKey(r => r.ApplicationId)
                .HasPrincipalKey(c=>c.Id);

            builder
                .HasOne(r => r.Role)
                .WithMany(c => (IEnumerable<T>)c.RoleClaims)
                .HasForeignKey(r => r.RoleId);

            builder
                .HasOne(r => r.Claim)
                .WithMany(c => (IEnumerable<T>)c.RoleClaims)
                .HasForeignKey(r => r.ClaimId);

            builder.HasIndex(p => new { p.ApplicationId, p.RoleId, p.ClaimId });
        }
    }
}