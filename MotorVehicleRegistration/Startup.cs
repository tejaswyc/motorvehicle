using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MotorVehicleRegistration.Startup))]
namespace MotorVehicleRegistration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
