using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcArcDemo.Startup))]
namespace MvcArcDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
