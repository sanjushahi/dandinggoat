﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DancingGoat.Helpers
{
    public static class RedirectHelpers
    {
        public static RedirectToRouteResult GetSelfConfigIndexResult(string message)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new
            {
                Action = "Index",
                Controller = "SelfConfig",
                Area = "Admin",
                Message = message
            }));
        }

        public static RedirectToRouteResult GetSelfConfigRecheckResult(string message)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new
            {
                Action = "Recheck",
                Controller = "SelfConfig",
                Area = "Admin",
                Message = message
            }));
        }

        public static RedirectToRouteResult GetHomeRedirectResult(string message)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new
            {
                Action = "Index",
                Controller = "Home",
                Area = "",
                Message = message
            }));
        }
    }
}