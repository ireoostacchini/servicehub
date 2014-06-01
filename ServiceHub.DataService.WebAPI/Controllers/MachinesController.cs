using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Http;
using ServiceHub.DataService.Application.Helpers;
using ServiceHub.DataService.Application.Mappers;
using ServiceHub.DataService.WebAPI.Helpers;
using ServiceHub.Infrastructure.Interfaces;
using ServiceHub.Model;
using ServiceHub.DataAccess.Interfaces;
using ServiceHub.DataAccess;
using ServiceHub.DataService.Application;
using ServiceHub.DataContracts;
using ServiceHub.DataContracts.Interfaces;

namespace ServiceHub.DataService.WebAPI.Controllers
{
    public class MachinesController : BaseController
    {
        IUnitOfWork _unitOfWork;
        ILogger _logger;

        public MachinesController(IUnitOfWork unitOfWork, ILogger logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // GET api/machines
        public HttpResponseMessage Get()
        {

            var machines = _unitOfWork.Machines.GetAll()
                .OrderBy(x => x.FriendlyName)
                .ToList()
                .Select(x => x.ToDto()).ToList();


            //convert nulls to zeros - so teh form drop-down can represent it as the first ('Choose...') option
            foreach (var machineDto in machines)
            {
                if (machineDto.CredentialsId == null) machineDto.CredentialsId = 0;
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, machines);


            return response;



        }



        // PUT /api/machines/5
        public HttpResponseMessage Put(int id, [FromBody] MachineDto machineDto)
        {

            //zero is passed back if the top 'null' option is selected inthe web form drop-down
         //   if (machineDto.CredentialsId == 0) machineDto.CredentialsId = null;

            //validate
            if (!ModelState.IsValid)
            {
                _logger.Error("MachinesController.Put failed: model state not valid");


                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Model state not valid")
                });
            }


            var machine = _unitOfWork.Machines.GetById(id);


            //check a machine exists
            if (machine == null)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Machine not found")
                });
            }

            //all's well - so update the machine

            //but first, validate that the data hasn't been changed by another user since we loaded it
            var machineRV = RowVersionHelper.ConvertToString(machine.RowVersion);

            if (machineRV != machineDto.Version)
            {
                _logger.Error("Concurrency exception - mismatched rowversions : " + machineRV  + " | " + machineDto.Version);

                throw new HttpResponseException(new HttpResponseMessage
                                                    {
                                                        StatusCode = HttpStatusCode.BadRequest,
                                                        Content = new StringContent("Concurrency exception")
                                                    });
            }

            machine.Update(machineDto);

            _unitOfWork.Commit();


            var response = Request.CreateResponse(HttpStatusCode.NoContent);

            //pass the updated rowversion info back in an eTag
            var version = RowVersionHelper.ConvertToString(machine.RowVersion);

            response.Headers.ETag = new EntityTagHeaderValue((QuotedString)version, true);

            return response;

        }

        // POST api/machine/
        public HttpResponseMessage Post([FromBody] Machine machineDto)
        {
            //zero is passed back if the top 'null' option is selected inthe web form drop-down
        //    if (machineDto.CredentialsId == 0) machineDto.CredentialsId = null;


            if (!ModelState.IsValid)
            {
                _logger.Error("MachinesController.Post failed: model state not valid");


                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Model state not valid")
                });
            }


            try
            {

                var returnedMachine = _unitOfWork.Machines.Add(machineDto);

                _unitOfWork.Commit();


                var response = Request.CreateResponse(HttpStatusCode.Created, returnedMachine);

                //return the uri that points to the new person - eg http://.../person/23
                var uri = VirtualPathUtility.AppendTrailingSlash(Request.RequestUri.AbsoluteUri) +
                          machineDto.MachineId.ToString();

                response.Headers.Location = new Uri(uri);

                return response;

            }
            catch (Exception ex)
            {
                _logger.Error("MachinesController.Post failed", ex);

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        // DELETE api/machine/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                //first check if it exists, and return 404 if not. This is the REST way...
                var machine = _unitOfWork.Machines.GetById(id);

                if (machine == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }


                _unitOfWork.Machines.Delete(machine);

                _unitOfWork.Commit();


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
