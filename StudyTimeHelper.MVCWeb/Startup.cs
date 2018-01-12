using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudyTimeHelper.MVCWeb.Startup))]
namespace StudyTimeHelper.MVCWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
