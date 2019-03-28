using CS.Common.EmailProvider;
using CustomFramework.Authorization.Utils;
using CustomFramework.WebApiUtils.Identity.Business;
using CustomFramework.WebApiUtils.Identity.Data;
using CustomFramework.WebApiUtils.Identity.Data.Repositories;
using CustomFramework.WebApiUtils.Identity.Models;
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

            services.AddScoped<DbContext, IdentityContext<TUser, TRole>>();
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddSingleton<IToken, Token>(p => IdentityConfig.Token);
            services.AddSingleton<IEmailConfig, EmailConfig>(p => IdentityConfig.EmailConfig);

            services.AddTransient<IClientApplicationRepository, ClientApplicationRepository>();

            services.AddTransient<ICustomUserManager<TUser>, CustomUserManager<TUser, TRole>>();
            services.AddTransient<ICustomRoleManager<TRole>, CustomRoleManager<TRole>>();
            services.AddTransient<IClientApplicationManager, ClientApplicationManager>();

            services.AddIdentity<TUser, TRole>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<IdentityContext<TUser, TRole>>()
                .AddDefaultTokenProviders();

            return services;
        }
    }

}