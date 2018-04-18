using CustomFramework.Data.ModelConfiguration;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.WebApiUtils.Authorization.Data.ModelConfigurations
{
    public class ClientApplicationUtilModelConfiguration<T> : BaseModelConfiguration<T, int> where T : ClientApplicationUtil
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.SpecialValue)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.ClientApplicationId)
                .IsRequired();

            builder
                .HasOne(r => r.ClientApplication)
                .WithOne(c => (T)c.ClientApplicationUtil)
                .HasForeignKey<ClientApplicationUtil>(r => r.ClientApplicationId);


        }
    }
}