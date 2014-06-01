using ServiceHub.DataService.WebAPI.Helpers;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace ServiceHub.DataService.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

 

        }

        /// <summary>
        /// Web API filters are registered separately from MVC ones
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterHttpFilters(HttpFilterCollection filters)
        {
            filters.Add(new CustomHttpExceptionFilter());
        }
    }
}