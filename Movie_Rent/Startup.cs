using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movie_Rent.Startup))]
namespace Movie_Rent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
