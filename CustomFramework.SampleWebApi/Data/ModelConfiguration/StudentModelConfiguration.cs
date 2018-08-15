using CustomFramework.Data.ModelConfiguration;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.SampleWebApi.Data.ModelConfiguration
{
    public class StudentModelConfiguration<T> : BaseModelNonUserConfiguration<T, int> where T : Student
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.StudentNo).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(25);
            builder.Property(p => p.Surname).IsRequired().HasMaxLength(25);




            builder.HasIndex(p => p.StudentNo).IsUnique();

        }
    }
}