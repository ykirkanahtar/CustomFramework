services.AddTransient<ICustomerRepository, CustomerRepository>();
services.AddTransient<ICustomerManager, CustomerManager>();
services.AddTransient<IValidator<CustomerRequest>, CustomerValidator>();
