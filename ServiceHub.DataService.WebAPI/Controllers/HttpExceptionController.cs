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

namespace ServiceHub.DataService.WebAPI.Controllers
{
    public class HttpExceptionController : BaseController
    {


        public HttpExceptionController()
        {

        }

        // GET api/services
        public string GetException()
        {

            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found!"));


        }



    }
}
