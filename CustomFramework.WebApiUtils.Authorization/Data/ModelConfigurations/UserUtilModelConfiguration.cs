using CustomFramework.Data.ModelConfiguration;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFramework.WebApiUtils.Authorization.Data.ModelConfigurations
{
    public class UserUtilModelConfiguration<T> : BaseModelNonUserConfiguration<T, int> where T : UserUtil
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.SpecialValue)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.UserId)
                .IsRequired();

            builder
                .HasOne(r => r.User)
                .WithOne(c => (T)c.UserUtil)
                .HasForeignKey<UserUtil>(r => r.UserId)
                .HasPrincipalKey<User>(c=>c.Id);
        }
    }
}