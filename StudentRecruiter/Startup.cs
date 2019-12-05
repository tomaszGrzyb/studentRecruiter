using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentRecruiter.Startup))]
namespace StudentRecruiter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
