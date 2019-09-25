using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(biblioteca_frontend.Startup))]
namespace biblioteca_frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
