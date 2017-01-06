using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PrairieCodeIdentity.Identity;

namespace PrairieCodeIdentity
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

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "CanAccessVIPArea",
                    policyBuilder => policyBuilder.RequireClaim("VIPNumber"));
            });

            services.AddScoped<IUserStore<CustomUser>, CustomStore>();
            services.AddScoped<IRoleStore<CustomRole>, CustomRoleStore>();
            services.AddScoped<IUserClaimStore<CustomUser>, CustomStore>();
            services.AddScoped<IPasswordHasher<CustomUser>, NoPasswordHasher>();
            services.AddIdentity<CustomUser, CustomRole>(options =>
            {
                options.Cookies.ApplicationCookie.AccessDeniedPath = options.Cookies.ApplicationCookie.LoginPath;
            }).AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //app.UseMiddleware<>()

            //app.Use(async (context, next) =>
            //{
            //    string loginCookie;
            //    if (context.Request.Cookies.TryGetValue("demo.username", out loginCookie))
            //    {
            //        context.User = new CustomUser(loginCookie);
            //    }
            //    await next.Invoke();
            //});

            //app.Use(async (context, next) =>
            //{
            //    context.User.HasClaim()
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

            app.UseStaticFiles();

            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationScheme = "Cookies",
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,

            //    LoginPath = new PathString("/Account/Login")
            //});

            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
