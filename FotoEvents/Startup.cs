using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FotoEvents.Startup))]
namespace FotoEvents
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
