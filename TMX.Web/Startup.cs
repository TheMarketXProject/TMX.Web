using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TMX.Web.Startup))]
namespace TMX.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
