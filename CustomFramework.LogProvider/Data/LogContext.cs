using CustomFramework.LogProvider.Data.ModelConfigurations;
using CustomFramework.LogProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.LogProvider.Data
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LogModelConfiguration<Log>());
        }
    }
}