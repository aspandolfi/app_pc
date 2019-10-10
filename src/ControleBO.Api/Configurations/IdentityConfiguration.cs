using ControleBO.Infra.CrossCutting.Identity.Configuration;
using ControleBO.Infra.CrossCutting.Identity.Context;
using ControleBO.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ControleBO.Api.Configurations
{
    public static class IdentityConfiguration
    {
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            services.AddScoped<ApplicationUserManager>();
        }
    }
}
