using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(euro1.Startup))]
namespace euro1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
