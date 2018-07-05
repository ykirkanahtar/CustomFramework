using CustomFramework.Data.ModelConfiguration;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.SampleWebApi.Data.ModelConfiguration
{
    public class SchoolModelConfiguration<T> : BaseModelConfiguration<T, int> where T : School
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(25);
            builder.Property(p => p.Address).IsRequired().HasMaxLength(255);

            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}