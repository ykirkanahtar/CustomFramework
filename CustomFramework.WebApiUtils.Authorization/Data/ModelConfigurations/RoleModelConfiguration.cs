using CustomFramework.Data.ModelConfiguration;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.WebApiUtils.Authorization.Data.ModelConfigurations
{
    public class RoleModelConfiguration<T> : BaseModelNonUserConfiguration<T, int> where T : Role
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.RoleName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.Description)
                .HasMaxLength(255);

            builder.HasIndex(p => p.RoleName);
        }
    }
}
