using System.Web.Http;
using Owin;

namespace IOAsync.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure web api routing
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", 
                "api/{controller}/{id}", 
                new { id = RouteParameter.Optional });

            // Use Web API middleware
            app.UseWebApi(config);

            // Display nice welcome page
            app.UseWelcomePage();
        }
    }
}
