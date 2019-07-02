using ControleBO.Api.Configurations;
using ControleBO.Infra.CrossCutting.Identity.Context;
using ControleBO.Infra.CrossCutting.Identity.Models;
using ControleBO.Infra.CrossCutting.IoC;
using ControleBO.Infra.Data.Context;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ControleBO.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ApplicationDbContext>();

            services.AddIdentity();

            services.AddJwt(Configuration);

            services.AddCors();

            services.AddResponseCompression();

            services.AddAutoMapperSetup();

            services.AddMediatR(typeof(Startup));

            services.AddMemoryCache();

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            SpcContext spcContext,
            ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseForwardedHeaders(new ForwardedHeadersOptions
            //{
            //    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
            //});

            app.UseResponseCompression();

            //app.UseHttpsRedirection();

            // Criação das estruturas e inserção 
            // de dados iniciais
            //new SpcContextInitializer(spcContext)
            //    .Initialize();

            // Criação de estruturas, usuários e permissões
            // na base do ASP.NET Identity Core (caso ainda não
            // existam)
            //new IdentityInitializer(applicationDbContext, userManager, roleManager)
            //    .Initialize();

            app.UseMvc();

            app.UseCors(x => x.AllowAnyOrigin());

            ConfigureDataDirectory(env);
        }

        private static void ConfigureDataDirectory(IHostingEnvironment env)
        {
            string baseDir = env.WebRootPath;

            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(baseDir, "App_Data"));
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            BootStrapper.RegisterServices(services);
        }
    }
}
