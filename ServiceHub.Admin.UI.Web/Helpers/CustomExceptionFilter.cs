using ServiceHub.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

using System.Web.Mvc;


namespace ServiceHub.Admin.UI.Web.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomExceptionFilter : HandleErrorAttribute 
    {

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                var logger = DependencyResolver.Current.GetService<ILogger>();
                logger.Error(filterContext.Exception.ToString());

                base.OnException(filterContext);
            }
        }
    }


}