using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleListingSystem.Startup))]
namespace VehicleListingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
