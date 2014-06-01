using ServiceHub.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;


namespace ServiceHub.DataService.WebAPI.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomHttpExceptionFilter : ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                var logger = DependencyResolver.Current.GetService<ILogger>();
                logger.Error(actionExecutedContext.Exception.ToString());

                //see http://www.tugberkugurlu.com/archive/asp-net-web-api-and-elmah-integration
                Elmah.ErrorSignal.FromCurrentContext().Raise(actionExecutedContext.Exception);

                base.OnException(actionExecutedContext);
            }
        }
    }


}