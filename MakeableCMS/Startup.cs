using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MakeableCMS.Startup))]
namespace MakeableCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
