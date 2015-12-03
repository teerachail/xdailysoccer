using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DailySoccerBackoffice.Startup))]
namespace DailySoccerBackoffice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
