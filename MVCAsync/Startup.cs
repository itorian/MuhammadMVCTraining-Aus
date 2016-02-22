using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAsync.Startup))]
namespace MVCAsync
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
