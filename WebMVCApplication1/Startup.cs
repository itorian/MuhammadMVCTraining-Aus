using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMVCApplication1.Startup))]
namespace WebMVCApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
