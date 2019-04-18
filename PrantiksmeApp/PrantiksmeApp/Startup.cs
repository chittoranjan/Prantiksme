using Microsoft.Owin;
using Owin;

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
