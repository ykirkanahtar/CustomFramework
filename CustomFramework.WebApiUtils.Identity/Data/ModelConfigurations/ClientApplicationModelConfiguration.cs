using CustomFramework.Data.ModelConfiguration;
using CustomFramework.WebApiUtils.Identity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.WebApiUtils.Identity.Data.ModelConfigurations
{
    public class ClientApplicationModelConfiguration<T> : BaseModelNonUserConfiguration<T, int> where T : ClientApplication
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.ClientApplicationName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.ClientApplicationCode)
                .IsRequired()
                .HasMaxLength(6);

            builder.Property(u => u.ClientApplicationPassword)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.SecurityStamp)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(p => p.ClientApplicationCode);
            builder.HasIndex(p => p.ClientApplicationName);
            builder.HasIndex(p => new { p.ClientApplicationCode, p.ClientApplicationPassword });

        }
    }

}