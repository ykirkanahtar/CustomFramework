using CustomFramework.Data.ModelConfiguration;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.SampleWebApi.Data.ModelConfiguration
{
    public class PlayerModelConfiguration<T> : BaseModelConfiguration<T, int> where T : Player
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.BirthDate)
                .IsRequired();
        }
    }
}
