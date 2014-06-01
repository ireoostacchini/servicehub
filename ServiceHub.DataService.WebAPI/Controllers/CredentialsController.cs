using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using ServiceHub.DataService.Application.Mappers;
using ServiceHub.Model;
using ServiceHub.DataAccess.Interfaces;
using ServiceHub.DataAccess;
using ServiceHub.DataService.Application;
using ServiceHub.DataContracts;
using ServiceHub.DataContracts.Interfaces;

namespace ServiceHub.DataService.WebAPI.Controllers
{
    public class CredentialsController : BaseController
    {

        IUnitOfWork _unitOfWork;

        public CredentialsController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        // GET api/credentials
        public HttpResponseMessage Get()
        {

            var creds = _unitOfWork.Credentials.GetAll()
                .OrderBy(x => x.Username)
                .ToList()
                .Select(x => x.ToDtoBrief())
                .ToList();

            var response = Request.CreateResponse(HttpStatusCode.OK, creds);
            


            return response;
        }


    }
}
