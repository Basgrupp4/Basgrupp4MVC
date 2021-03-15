using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Basgrupp4MVC.Startup))]
namespace Basgrupp4MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
