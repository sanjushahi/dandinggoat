using System.Web.Mvc;
using System.Web.Routing;
using DancingGoat.Localization;

namespace DancingGoat
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var route = routes.MapRoute(
                name: "Articles",
                url: "{language}/articles",
                defaults: new { language = LanguageClient.DEFAULT_LANGUAGE, controller = "Articles", action = "Index" },
                constraints: new { language = new LanguageConstraint() }
            );
            route.RouteHandler = new LocalizedMvcRouteHandler(LanguageClient.DEFAULT_LANGUAGE);
            route = routes.MapRoute(
                name: "Article",
                url: "{language}/articles/{urlSlug}",
                defaults: new { language = LanguageClient.DEFAULT_LANGUAGE, controller = "Articles", action = "Show", urlSlug = ""},
                constraints: new { language = new LanguageConstraint() }
            );
            route.RouteHandler = new LocalizedMvcRouteHandler(LanguageClient.DEFAULT_LANGUAGE);

            route = routes.MapRoute(
                name: "Coffees",
                url: "{language}/coffee",
                defaults: new { language = LanguageClient.DEFAULT_LANGUAGE, controller = "Coffes", action = "Index" },
                constraints: new { language = new LanguageConstraint() }
            );
            route.RouteHandler = new LocalizedMvcRouteHandler(LanguageClient.DEFAULT_LANGUAGE);
            route = routes.MapRoute(
                name: "Coffee",
                url: "{language}/coffee/{urlSlug}",
                defaults: new { language = LanguageClient.DEFAULT_LANGUAGE, controller = "Coffees", action = "Show", urlSlug = "" },
                constraints: new { language = new LanguageConstraint() }
            );
            route.RouteHandler = new LocalizedMvcRouteHandler(LanguageClient.DEFAULT_LANGUAGE);

            route = routes.MapRoute(
                name: "LocalizedContent", 
                url: "{language}/{controller}/{action}/{urlSlug}",
                defaults: new { language = LanguageClient.DEFAULT_LANGUAGE, controller = "Home", action = "Index", urlSlug = UrlParameter.Optional},
                constraints: new { language = new LanguageConstraint() }
            );
            route.RouteHandler = new LocalizedMvcRouteHandler(LanguageClient.DEFAULT_LANGUAGE);

            // Display a custom view when no route is found
            routes.MapRoute(
                name: "Error",
                url: "{*url}",
                defaults: new { language = LanguageClient.DEFAULT_LANGUAGE, controller = "Errors", action = "NotFound" }
            );

        }
    }
}