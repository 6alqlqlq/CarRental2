using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestCarRental3.Startup))]
namespace TestCarRental3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
