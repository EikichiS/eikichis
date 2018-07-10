using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootstrapSite1.Startup))]
namespace BootstrapSite1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
