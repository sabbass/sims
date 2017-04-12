using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResultInformation.Startup))]
namespace ResultInformation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
