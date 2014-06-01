using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;
using ServiceHub.Model;
using ServiceHub.DataContracts;

namespace ServiceHub.DataService.Application.Mappers
{
    public static class ServiceDtoMapper
    {

        static ServiceDtoMapper()
        {
            Mapper.CreateMap<Service, ServiceDto>();

        }



        public static ServiceDto ToDto(this Service Service)
        {
            return Mapper.Map<Service, ServiceDto>(Service);
        }


    }
}
