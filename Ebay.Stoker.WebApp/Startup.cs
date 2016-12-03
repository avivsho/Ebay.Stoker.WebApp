using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ebay.Stoker.WebApp.Startup))]
namespace Ebay.Stoker.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
