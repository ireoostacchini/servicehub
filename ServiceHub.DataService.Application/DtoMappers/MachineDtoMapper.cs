using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;
using ServiceHub.DataService.Application.Helpers;
using ServiceHub.Model;
using ServiceHub.DataContracts;

namespace ServiceHub.DataService.Application.Mappers
{
    public static class MachineDtoMapper
    {

        static MachineDtoMapper()
        {
            Mapper.CreateMap<Machine, MachineDto>()
                .ForMember(d => d.Version, x => x.MapFrom(y => RowVersionHelper.ConvertToString(y.RowVersion)));

            Mapper.CreateMap<Credentials, CredentialsDto>();    
        }

        public static MachineDto ToDto(this Machine machine)
        {
            return Mapper.Map<Machine, MachineDto>(machine);
        }


    }
}
