using System.Collections.Generic;
using System.Globalization;
using System.IO;
using AutoMapper;
using CustomFramework.Authorization;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Extensions;
using CustomFramework.Data.Extensions;
using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.SampleWebApi.Business;
using CustomFramework.SampleWebApi.Data;
using CustomFramework.SampleWebApi.Data.Seeding;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.SampleWebApi.Resources;
using CustomFramework.SampleWebApi.Validators;
using CustomFramework.WebApiUtils.Authorization.Data.Seeding;
using CustomFramework.WebApiUtils.Authorization.Extensions;
using CustomFramework.WebApiUtils.Authorization.Filters;
using CustomFramework.WebApiUtils.Extensions;
using CustomFramework.WebApiUtils.Middlewares;
using CustomFramework.WebApiUtils.Resources;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CustomFramework.SampleWebApi
{
    public class Startup
    {
        public static AppSettings AppSettings { get; private set; }
        public static SeedAuthorizationData SeedAuthorizationData { get; private set; }
        public static SeedWebApiData SeedWebApiData { get; private set; }
        public static string ConnectionString { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddUserSecrets<Startup>();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            ConnectionString = Configuration.GetValue<string>("ConnectionStrings:ApplicationContext");

            AppSettings = new AppSettings();
            Configuration.GetSection("AppSettings").Bind(AppSettings);

            SeedAuthorizationData = new SeedAuthorizationData();
            Configuration.GetSection("SeedingAuthorizationData").Bind(SeedAuthorizationData);

            SeedWebApiData = new SeedWebApiData();
            //Configuration.GetSection("SeedingWebApiData").Bind(SeedWebApiData);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSqlServer<ApplicationContext>(ConnectionString);
            services.AddPostgreSqlServer<ApplicationContext>(ConnectionString);

            services.AddJwtAuthentication(AppSettings.Token.Audience, AppSettings.Token.Issuer, AppSettings.Token.Key);

            services.AddCustomAuthorization(new List<CustomAuthorizationPolicy>
            {
                new CustomAuthorizationPolicy
                {
                    Name = "Permission",
                    AuthorizationRequirements = new List<IAuthorizationRequirement>
                    {
                        new PermissionAuthorizationRequirement(),
                    }
                }
            });

            services.AddSwaggerDocumentation();

            services.AddWebApiUtilServices();

            services.AddAutoMapper();
            services.AddAuthorizationModels();

            services.AddTransient<ILocalizationService, LocalizationService>();

            var cultureInfos = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("tr-TR"),
            };

            services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                options.SupportedCultures = cultureInfos;
                options.SupportedUICultures = cultureInfos;
                options.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());
            });

            /*********Managers*********/
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICurrentAccountManager, CurrentAccountManager>();

            services.AddTransient<ICurrentAccountManager2, CurrentAccountManager2>();
            services.AddTransient<ICustomerManager2, CustomerManager2>();
            /*********Managers*********/

            /************Fluent Validation************/
            services.AddTransient<IValidator<CustomerRequest>, CustomerValidator>();
            services.AddTransient<IValidator<CurrentAccountRequest>, CurrentAccountValidator>();
            /************Fluent Validation************/


            services.AddMvc(options =>
                {
                    options.Filters.Add(typeof(ValidateModelAttribute));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    })
                .AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseSwaggerDocumentation();

            app.UseMiddleware<ErrorWrappingMiddleware>();

            app.UseMvc();
        }
    }
}
