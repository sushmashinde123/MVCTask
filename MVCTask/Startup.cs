using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCTask.Startup))]
namespace MVCTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
