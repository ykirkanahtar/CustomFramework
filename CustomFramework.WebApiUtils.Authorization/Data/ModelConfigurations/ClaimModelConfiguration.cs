using CustomFramework.Data.ModelConfiguration;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.WebApiUtils.Authorization.Data.ModelConfigurations
{
    public class ClaimModelConfiguration<T> : BaseModelNonUserConfiguration<T, int> where T : Claim
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.CustomClaim)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(p => p.CustomClaim);
        }
    }
}