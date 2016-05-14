using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MapPOC.Startup))]
namespace MapPOC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
