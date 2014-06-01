using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ServiceHub.Model;
using ServiceHub.DataAccess.Interfaces;
using ServiceHub.DataAccess;
using ServiceHub.DataService.Application;
using ServiceHub.DataContracts;
using ServiceHub.DataContracts.Interfaces;
using ServiceHub.Infrastructure.Interfaces;

namespace ServiceHub.DataService.WebAPI.Controllers
{
    public class ExceptionController : BaseController
    {
        private ILogger _logger;

        public ExceptionController(ILogger logger)
        {
            _logger = logger;
        }

        // GET api/services
        public string GetException()
        {

            _logger.Debug("just testing");

            throw new Exception("nooo!");

        }


     
    }
}
