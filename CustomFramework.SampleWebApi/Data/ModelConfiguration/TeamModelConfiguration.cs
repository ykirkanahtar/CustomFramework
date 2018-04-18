using CustomFramework.Data.ModelConfiguration;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.SampleWebApi.Data.ModelConfiguration
{
    public class TeamModelConfiguration<T> : BaseModelConfiguration<T, int> where T : Team
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.Color)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}
