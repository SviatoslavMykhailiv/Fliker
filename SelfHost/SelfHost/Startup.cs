using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
[assembly: OwinStartup(typeof(SelfHost.Startup))]

namespace SelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(name: "ApiRoute", routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new {id = RouteParameter.Optional});

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
            app.MapSignalR();
        }
    }
}
