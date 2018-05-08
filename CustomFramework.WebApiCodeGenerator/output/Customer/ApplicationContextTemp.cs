public virtual DbSet<Customer> Customers { get; set; }
modelBuilder.ApplyConfiguration(new CustomerModelConfiguration<Customer>());