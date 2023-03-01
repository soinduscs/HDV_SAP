using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovilUtiles.Startup))]
namespace MovilUtiles
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
