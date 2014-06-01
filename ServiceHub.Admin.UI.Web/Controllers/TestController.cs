using ServiceHub.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceHub.Admin.UI.Web.Controllers
{
    public class TestController : MvcBaseController
    {
        private ILogger _logger;

        public TestController(ILogger logger)
        {
            _logger = logger;
        }


        //
        // GET: /Test/

        public ActionResult Index()
        {


            throw new Exception("nooooo");
            _logger.Debug("Test");

            return View();
        }

    }
}
