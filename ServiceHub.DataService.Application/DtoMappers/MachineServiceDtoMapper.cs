using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;
using ServiceHub.Model;
using ServiceHub.DataContracts;

namespace ServiceHub.DataService.Application.Mappers
{
    public static class MachineServiceDtoMapper
    {

        static MachineServiceDtoMapper()
        {
            Mapper.CreateMap<MachineService, MachineServiceDto>();

        }

        public static MachineServiceDto ToDto(this MachineService machineService)
        {
            return Mapper.Map<MachineService, MachineServiceDto>(machineService);
        }


    }
}
