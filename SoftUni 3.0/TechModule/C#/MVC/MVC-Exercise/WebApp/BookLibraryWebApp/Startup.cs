using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookLibraryWebApp.Startup))]
namespace BookLibraryWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
