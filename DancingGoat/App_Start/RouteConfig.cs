using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using DancingGoat.Areas.Admin;
using DancingGoat.Localization;
using DancingGoat.Models;
using KenticoCloud.Delivery;

namespace DancingGoat
{
    public class RouteConfig
    {
        public const string NavCoffee = "coffee_navigation";
        public const string NavArticles = "articles_navigation";
        public const string NavPartnership = "partnership_navigation";
        public const string NavCafes = "cafes_navigation";

        public static readonly Dictionary<string, string> RegisteredControllersByNavigationCodename = new Dictionary<string, string>
        {
            {NavCoffee, "Coffees"},
            {NavArticles, "Articles"},
            {NavPartnership, "Partnership"},
            {NavCafes, "Cafes"}
        };

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Get navigation
            var previewToken = AppSettingProvider.PreviewToken;
            var projectId = AppSettingProvider.ProjectId ?? AppSettingProvider.DefaultProjectId;

            var client =
                !string.IsNullOrEmpty(previewToken) ?
                    new DeliveryClient(projectId.Value.ToString(), previewToken) :
                    new DeliveryClient(projectId.Value.ToString());

            client.CodeFirstModelProvider.TypeProvider = new CustomTypeProvider();

            var navigationResponse = client.GetItemsAsync<Navigation>(new EqualsFilter("system.type", Navigation.Codename), new DepthParameter(2)).Result;
            var navigation = navigationResponse.Items.FirstOrDefault();
            var navigationItems = navigation?.NavigationItems.Cast<NavigationItem>().ToList();

            if (navigation == null || navigationItems == null || !navigationItems.Any())
            {
                throw new Exception("Can't retrieve navigation");
            }

            // Get dynamic URL segments
            var articlesUrlSegment = navigationItems.First(n => n.System.Codename == NavArticles).UrlSegment;
            var coffeeUrlSegment = navigationItems.First(n => n.System.Codename == NavCoffee).UrlSegment;
            var partnershipUrlSegment = navigationItems.First(n => n.System.Codename == NavPartnership).UrlSegment;
            var cafesUrlSegment = navigationItems.First(n => n.System.Codename == NavCafes).UrlSegment;

            // Register known routes
            var route = routes.MapRoute(
                name: "Articles",
                url: "{language}/" + articlesUrlSegment,
                defaults: new { language = LanguageClient.DEFAULT_LANGUAGE, controller = "Articles", action = "Index" },
                constraints: new { language = new LanguageConstraint() }
            );
            route.RouteHandler = new LocalizedMvcRouteHandler(LanguageClient.DEFAULT_LANGUAGE);

            route = routes.MapRoute(
                name: "Article",
                url: "{language}/" + articlesUrlSegment + "/{urlSlug}",
                defaults: new { language = LanguageClient.DEFAULT_LANGUAGE, controller = "Articles", action = "Show", urlSlug = ""},
                constraints: new { language = new LanguageConstraint() }
            );
            route.RouteHandler = new LocalizedMvcRouteHandler(LanguageClient.DEFAULT_LANGUAGE);

            route = routes.MapRoute(
                name: "Coffees",
                url: "{language}/" + coffeeUrlSegment,
                defaults: new { language = LanguageClient.DEFAULT_LANGUAGE, controller = "Coffees", action = "Index" },
                constraints: new { language = new LanguageConstraint() }
            );
            route.RouteHandler = new LocalizedMvcRouteHandler(LanguageClient.DEFAULT_LANGUAGE);

            route = routes.MapRoute(
                name: "Coffee",
                url: "{language}/" + coffeeUrlSegment + "/{urlSlug}",
                defaults: new { language = LanguageClient.DEFAULT_LANGUAGE, controller = "Coffees", action = "Show", urlSlug = "" },
                constraints: new { language = new LanguageConstraint() }
            );
            route.RouteHandler = new LocalizedMvcRouteHandler(LanguageClient.DEFAULT_LANGUAGE);

            route = routes.MapRoute(
                name: "Partnership",
                url: "{language}/" + partnershipUrlSegment,
                defaults: new { language = LanguageClient.DEFAULT_LANGUAGE, controller = "Partnership", action = "Index" },
                constraints: new { language = new LanguageConstraint() }
            );
            route.RouteHandler = new LocalizedMvcRouteHandler(LanguageClient.DEFAULT_LANGUAGE);

            route = routes.MapRoute(
                name: "Cafes",
                url: "{language}/" + cafesUrlSegment,
                defaults: new { language = LanguageClient.DEFAULT_LANGUAGE, controller = "Cafes", action = "Index" },
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

            // Register custom routes
            routes.MapRoute(
                name: "Impersonation",
                url: "impersonate" ,
                defaults: new { controller = "Impersonation", action = "Index" }
            );

            // Display a custom view when no route is found
            routes.MapRoute(
                name: "Error",
                url: "{*url}",
                defaults: new { language = LanguageClient.DEFAULT_LANGUAGE, controller = "Errors", action = "NotFound" }
            );

        }
    }
}