using ServiceHub.DataService.WebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServiceHub.DataService.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //ie don't pass detailed error info to the client
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;

            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
