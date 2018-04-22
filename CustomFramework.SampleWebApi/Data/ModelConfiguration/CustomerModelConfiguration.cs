using CustomFramework.Data.ModelConfiguration;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.SampleWebApi.Data.ModelConfiguration
{
    public class CustomerModelConfiguration<T> : BaseModelConfiguration<T, int> where T : Customer
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.CustomerNo)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(p => p.CustomerNo)
                .IsUnique();
        }
    }
}
