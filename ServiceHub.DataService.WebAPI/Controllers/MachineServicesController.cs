using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class MachineServicesController : BaseController
    {

        IUnitOfWork _unitOfWork;

        public MachineServicesController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        // GET api/services
        public IEnumerable<MachineServiceDto> Get()
        {

            var machineServices = _unitOfWork.MachineServices.GetAll()
                  .OrderBy(x => x.Machine.FriendlyName).ThenBy(x => x.Service.FriendlyName)
                  .ToList();

            return machineServices
                   .Select(x => x.ToDto())
                   .ToList();
        }


    }
}
