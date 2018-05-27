using System.Collections.Generic;
using CustomFramework.Data.ModelConfiguration;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.SampleWebApi.Data.ModelConfiguration
{
    public class CourseModelConfiguration<T> : BaseModelConfiguration<T, int> where T : Course
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.CourseNo).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(25);
            builder.Property(p => p.TeacherId).IsRequired();


            builder.HasOne(r => r.Teacher).WithMany(c => (IEnumerable<T>)c.Courses).HasForeignKey(r => r.TeacherId).HasPrincipalKey(c => c.Id).IsRequired();


            builder.HasIndex(p => p.CourseNo).IsUnique();
            builder.HasIndex(p => p.TeacherId);
        }
    }
}