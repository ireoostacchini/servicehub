﻿using ServiceHub.Admin.UI.Web.Helpers;
using System.Web;
using System.Web.Mvc;

namespace ServiceHub.Admin.UI.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new CustomExceptionFilter());
        }
    }
}