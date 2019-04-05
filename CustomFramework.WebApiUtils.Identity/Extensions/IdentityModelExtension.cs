using System.Threading.Tasks;
using CS.Common.EmailProvider;
using CustomFramework.Authorization.Utils;
using CustomFramework.WebApiUtils.Identity.Business;
using CustomFramework.WebApiUtils.Identity.Data;
using CustomFramework.WebApiUtils.Identity.Data.Repositories;
using CustomFramework.WebApiUtils.Identity.Handlers;
using CustomFramework.WebApiUtils.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Identity.Extensions
{
    public static class IdentityModelExtension<TUser, TRole>
        where TUser : CustomUser
    where TRole : CustomRole
    {
        public static IdentityModel IdentityConfig { get; set; }
        public static IServiceCollection AddIdentityModel(IServiceCollection services, IdentityModel identityModel)
        {
            IdentityConfig = identityModel;

            services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddScoped<DbContext, IdentityContext<TUser, TRole>>();
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddSingleton<IToken, Token>(p => IdentityConfig.Token);
            services.AddSingleton<IEmailConfig, EmailConfig>(p => IdentityConfig.EmailConfig);

            services.AddTransient<IClientApplicationRepository, ClientApplicationRepository>();

            services.AddTransient<ICustomUserManager<TUser>, CustomUserManager<TUser, TRole>>();
            services.AddTransient<ICustomRoleManager<TRole>, CustomRoleManager<TUser, TRole>>();
            services.AddTransient<IClientApplicationManager, ClientApplicationManager>();
            services.AddTransient<IPermissionManager, PermissionManager<TUser, TRole>>();

            services.AddIdentity<TUser, TRole>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<IdentityContext<TUser, TRole>>()
                .AddDefaultTokenProviders();

            // ===== Configure Identity =======
            services.ConfigureApplicationCookie(options =>
            {
                //options.Cookie.Name = "auth_cookie";
                //options.Cookie.SameSite = SameSiteMode.None;
                //options.LoginPath = new PathString("/api/contests");
                //options.AccessDeniedPath = new PathString("/api/contests");

                // Not creating a new object since ASP.NET Identity has created
                // one already and hooked to the OnValidatePrincipal event.
                // See https://github.com/aspnet/AspNetCore/blob/5a64688d8e192cacffda9440e8725c1ed41a30cf/src/Identity/src/Identity/IdentityServiceCollectionExtensions.cs#L56
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };
            });

            return services;
        }
    }

}