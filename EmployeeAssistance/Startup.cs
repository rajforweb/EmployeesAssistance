using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeAssistance.Startup))]
namespace EmployeeAssistance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
