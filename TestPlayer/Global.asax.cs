using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestPlayer
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "", new { controller = "Tests", Action = "List", page = 1 });
            routes.MapRoute(null, "Page{page}",
                new { controller = "Tests", Action = "List" },
                new { page = @"\d+" }
                );

            ///routes.MapRoute("Blocks", "Blocks", new {controller = "Blocks", Action = "List"});

            //routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Tests", acttion = "ForDefaultRoute", id = "" });
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "", acttion = "", id = "" });

            //routes.MapRoute(null, "", new { controller = "Blocks", Action = "List"});


            //routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Tests", action = "List", id = UrlParameter.Optional } // Parameter defaults
            //);

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory());
        }
    }
}