using System.Collections.Generic;
using System.IO;
using AutoMapper;
using CustomFramework.Authorization;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Extensions;
using CustomFramework.Data.Extensions;
using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.SampleWebApi.Business;
using CustomFramework.SampleWebApi.Data;
using CustomFramework.WebApiUtils.Authorization.Data.Seeding;
using CustomFramework.WebApiUtils.Authorization.Extensions;
using CustomFramework.WebApiUtils.Extensions;
using CustomFramework.WebApiUtils.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CustomFramework.SampleWebApi
{
    public class Startup
    {
        public static AppSettings AppSettings { get; private set; }

        public static SeedAuthorizationData SeedData { get; private set; }
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
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSqlServer<ApplicationContext>(ConnectionString);

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

            /*********Managers*********/
            services.AddTransient<IMatchManager, MatchManager>();
            services.AddTransient<IPlayerManager, PlayerManager>();
            services.AddTransient<IStatManager, StatManager>();
            services.AddTransient<ITeamManager, TeamManager>();
            /*********Managers*********/

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
