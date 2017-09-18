using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DancingGoat.Models;

namespace DancingGoat.Helpers.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string ActionFromContentItem(this UrlHelper helper, object contentItem)
        {
            if (contentItem is Coffee)
            {
                return helper.Action("Show", "Coffees", new { urlSlug = ((Coffee)contentItem).UrlLabel });
            }
            if (contentItem is Article)
            {
                return helper.Action("Show", "Articles", new { urlSlug = ((Article)contentItem).UrlLabel });
            }
            if (contentItem is NavigationItem)
            {
                return helper.Action("Index", RouteConfig.RegisteredControllersByNavigationCodename[((NavigationItem)contentItem).System.Codename]);
            }

            return helper.Action("NotFound", "Errors");
        }
    }
}