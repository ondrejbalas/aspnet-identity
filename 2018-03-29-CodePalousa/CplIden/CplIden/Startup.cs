﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CplIden.CodePalousa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CplIden
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
            services.AddMvc();

            services.AddScoped<IUserStore<CustomUser>, CustomStore>();
            services.AddScoped<IRoleStore<CustomRole>, CustomRoleStore>();
            services.AddScoped<IPasswordHasher<CustomUser>, NoPasswordHasher>();
            services.AddIdentity<CustomUser, CustomRole>().AddDefaultTokenProviders();

            services.AddSingleton<IAuthorizationHandler, SpeciesHandler>();

            services.AddScoped<IUserClaimsPrincipalFactory<CustomUser>, CustomUserClaimsPrincipalFactory>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("MemberSection",
                    policy => policy.Requirements.Add(new SpeciesRequirement(Species.Cat)));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
