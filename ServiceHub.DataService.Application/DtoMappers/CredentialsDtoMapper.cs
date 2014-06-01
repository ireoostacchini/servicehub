using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;
using ServiceHub.Model;
using ServiceHub.DataContracts;

namespace ServiceHub.DataService.Application.Mappers
{
    public static class CredentialsDtoMapper
    {

        static CredentialsDtoMapper()
        {
            Mapper.CreateMap<Credentials, CredentialsDto>();

        }



        public static CredentialsDto ToDto(this Credentials Credentials)
        {
            return Mapper.Map<Credentials, CredentialsDto>(Credentials);
        }


    }
}
