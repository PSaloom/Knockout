using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameCards.Startup))]
namespace GameCards
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
