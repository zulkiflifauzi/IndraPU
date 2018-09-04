using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndraPU.Startup))]
namespace IndraPU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
