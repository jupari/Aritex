using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aritex.Backend.Startup))]
namespace Aritex.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
