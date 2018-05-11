using System;
using System.Linq;
using CustomFramework.Data.Enums;
using CustomFramework.Data.Utils;
using CustomFramework.SampleWebApi.Data.ModelConfiguration;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.WebApiUtils.Authorization.Data;
using CustomFramework.WebApiUtils.Authorization.Data.Seeding;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.SampleWebApi.Data
{
    public class ApplicationContext : AuthorizationContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }

        /*************DbSets*************/

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        /*********End of DbSets**********/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /****************ModelConfigurations**************/
            modelBuilder.ApplyConfiguration(new StudentModelConfiguration<Student>());
            modelBuilder.ApplyConfiguration(new CourseModelConfiguration<Course>());
            modelBuilder.ApplyConfiguration(new TeacherModelConfiguration<Teacher>());
            modelBuilder.ApplyConfiguration(new StudentCourseModelConfiguration<StudentCourse>());
            /*************End of ModelConfigurations**********/


            Startup.SeedAuthorizationData.SeedClientApplicationData(modelBuilder);

            Startup.SeedAuthorizationData.SeedUserData(modelBuilder);

            Startup.SeedAuthorizationData.SeedRoleData(modelBuilder);

            Startup.SeedAuthorizationData.SeedRoleEntityData(modelBuilder);

            //https://stackoverflow.com/questions/46526230/disable-cascade-delete-on-ef-core-2-globally
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.SetModelToSnakeCase();
        }
    }
}