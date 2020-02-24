using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiwTienda.Startup))]
namespace MiwTienda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
