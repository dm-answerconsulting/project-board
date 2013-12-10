﻿using ProjectBoard.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProjectBoard.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
