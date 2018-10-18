using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(miniPhoneweb.Startup))]
namespace miniPhoneweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
