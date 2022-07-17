using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gifts.Startup))]
namespace Gifts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
