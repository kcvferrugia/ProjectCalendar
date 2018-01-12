using System.Web.Mvc;
using System.Web.Routing;

namespace StudyTimeHelper.MVCWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "EditEvent",
            //    "Edit/{EventId}",
            //    new { controller = "Event", action = "Edit" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}