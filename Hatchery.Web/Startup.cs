using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hatchery.Web.Startup))]
namespace Hatchery.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
