using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using IdenTest.Auth;
using IdenTest.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>; 

[assembly: OwinStartup(typeof(IdenTest.Startup))]
namespace IdenTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            //app.Use(new Func<AppFunc, AppFunc>(next => (async context =>
            //{
            //    var loginCookie = HttpContext.Current.Request.Cookies.Get("demo.username");
            //    if (loginCookie != null)
            //    {
            //        HttpContext.Current.User = new CustomUser(loginCookie.Value);
            //    }
            //    await next.Invoke(context);
            //})));
        }
    }
}