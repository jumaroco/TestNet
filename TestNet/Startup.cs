using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestNet.Startup))]
namespace TestNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
