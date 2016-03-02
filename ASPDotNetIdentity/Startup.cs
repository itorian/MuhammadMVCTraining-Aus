using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPDotNetIdentity.Startup))]
namespace ASPDotNetIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
