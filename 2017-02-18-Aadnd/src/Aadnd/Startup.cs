﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aadnd.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Aadnd
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddScoped<IUserStore<CustomUser>, CustomStore>();
            services.AddScoped<IRoleStore<CustomRole>, CustomRoleStore>();
            services.AddScoped<IPasswordHasher<CustomUser>, NoPasswordHasher>();
            services.AddIdentity<CustomUser, CustomRole>().AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("MemberSection",
                    policy => policy.Requirements.Add(new SpeciesRequirement(Species.Human)));
            });

            services.AddSingleton<IAuthorizationHandler, SpeciesHandler>();

            services.AddScoped<IUserClaimsPrincipalFactory<CustomUser>, CustomUserClaimsPrincipalFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //app.Use(async (context, next) =>
            //{
            //    string loginCookie;
            //    if (context.Request.Cookies.TryGetValue("demo.username", out loginCookie))
            //    {
            //        context.User = new CustomUser(loginCookie);
            //    }
            //    await next.Invoke();
            //});

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIdentity();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
