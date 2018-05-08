namespace CustomFramework.SampleWebApi.Data.ModelConfiguration
{
    public class CustomerModelConfiguration<T> : BaseModelConfiguration<T, {idFieldDataType}> where T : Customer
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            	builder.Property(p => p.CustomerNo).IsRequired().HasMaxLength(25);
	builder.Property(p => p.Name).IsRequired().HasMaxLength(25);
	builder.Property(p => p.Surname).IsRequired().HasMaxLength(25);
	builder.Property(p => p.CurrentAccounts).IsRequired();


            

            	builder.HasIndex(p => p.CustomerNo).IsUnique();

        }
    }
}