using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wish2DishWeb.Startup))]
namespace Wish2DishWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
