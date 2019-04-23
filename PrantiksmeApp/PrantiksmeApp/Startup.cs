using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using PrantiksmeApp.Models.IdentityModels;

[assembly: OwinStartupAttribute(typeof(PrantiksmeApp.Startup))]
namespace PrantiksmeApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
