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

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CurrentAccount> CurrentAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerModelConfiguration<Customer>());
            modelBuilder.ApplyConfiguration(new CurrentAccountModelConfiguration<CurrentAccount>());

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