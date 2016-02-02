using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormApplication1.Startup))]
namespace WebFormApplication1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
