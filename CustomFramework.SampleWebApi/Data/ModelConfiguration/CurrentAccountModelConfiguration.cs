using System.Collections.Generic;
using CustomFramework.Data.ModelConfiguration;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.SampleWebApi.Data.ModelConfiguration
{
    public class CurrentAccountModelConfiguration<T> : BaseModelConfiguration<T, int> where T : CurrentAccount
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(p => p.CustomerId)
                .IsRequired();

            builder
                .HasOne(r => r.Customer)
                .WithMany(c => (IEnumerable<T>) c.CurrentAccounts)
                .HasForeignKey(r => r.CustomerId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            builder.HasIndex(p => p.Code).IsUnique();
        }
    }
}
