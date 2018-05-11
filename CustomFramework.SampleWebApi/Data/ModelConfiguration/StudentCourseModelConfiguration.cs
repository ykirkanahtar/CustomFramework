using System.Collections.Generic;
using CustomFramework.Data.ModelConfiguration;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.SampleWebApi.Data.ModelConfiguration
{
    public class StudentCourseModelConfiguration<T> : BaseModelConfiguration<T, int> where T : StudentCourse
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.StudentId).IsRequired();
            builder.Property(p => p.CourseId).IsRequired();


            builder.HasOne(r => r.Student).WithMany(c => (IEnumerable<T>)c.StudentCourses).HasForeignKey(r => r.StudentId).HasPrincipalKey(c => c.Id).IsRequired();
            builder.HasOne(r => r.Course).WithMany(c => (IEnumerable<T>)c.StudentCourses).HasForeignKey(r => r.CourseId).HasPrincipalKey(c => c.Id).IsRequired();

        }
    }
}