using CustomFramework.Data.ModelConfiguration;
using CustomFramework.LogProvider.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.LogProvider.Data.ModelConfigurations
{
    public class LogModelConfiguration<T> : BaseModelNonUserConfiguration<T, long> where T : Log
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Request).IsRequired().HasMaxLength(2500);
            builder.Property(p => p.RequestTime).IsRequired();
            builder.Property(p => p.Response).IsRequired().HasMaxLength(5000);
            builder.Property(p => p.ResponseTime).IsRequired();
            builder.Property(p => p.LoggedUserId);
        }
    }
}