﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ServiceHub.DataService.Application.Interfaces;
using ServiceHub.DataAccess;
using ServiceHub.DataAccess.Interfaces;
using ServiceHub.DataService.Application;
using ServiceHub.DataContracts.Interfaces;

namespace ServiceHub.DataService.WebAPI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            FilterConfig.RegisterHttpFilters(GlobalConfiguration.Configuration.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);



            new DatabaseManager().InitializeDatabase();


          
        }

       
    }
}