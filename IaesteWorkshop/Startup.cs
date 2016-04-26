using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IaesteWorkshop.Startup))]
namespace IaesteWorkshop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
