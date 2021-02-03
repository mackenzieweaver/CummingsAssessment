using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CummingsAssessment.Startup))]
namespace CummingsAssessment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
