using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MatchManagement.Startup))]
namespace MatchManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
