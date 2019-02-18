using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(brouillon.Startup))]
namespace brouillon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
