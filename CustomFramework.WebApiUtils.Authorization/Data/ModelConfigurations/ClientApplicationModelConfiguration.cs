using CustomFramework.Data.ModelConfiguration;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.WebApiUtils.Authorization.Data.ModelConfigurations
{
    public class ClientApplicationModelConfiguration<T> : BaseModelConfiguration<T, int> where T : ClientApplication
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
        }
    }
}