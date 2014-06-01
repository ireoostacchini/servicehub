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
    public class ServicesController : BaseController
    {

        IUnitOfWork _unitOfWork;

        public ServicesController( IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        // GET api/services
        public HttpResponseMessage Get()
        {

            var services = _unitOfWork.Services.GetAll()
                .OrderBy(x => x.FriendlyName)
                .ToList()
                .Select(x => x.ToDto())
                .ToList();

            var response = Request.CreateResponse(HttpStatusCode.OK, services);



            return response;
        }


    }
}
