using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppInsightDemo.Startup))]
namespace AppInsightDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
