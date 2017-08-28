using System.Web.Mvc;
using System.Web.Routing;

namespace Andyskl.PleaseRepost
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_OnStart()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
               "Authentication", // Route name
               "Auth/", // URL with parameters
               new { controller = "Auth", action = "Login", id = UrlParameter.Optional }, new[] { "Akelon.Works" } // Parameter defaults
               );
            routes.MapRoute(
                "Main", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Main", action = "Index", id = UrlParameter.Optional }, new[] { "Akelon.Works" } // Parameter defaults
                );
        }
    }
}