using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlyWith.Startup))]
namespace FlyWith
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
