using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;
using ServiceHub.Model;
using ServiceHub.DataContracts;

namespace ServiceHub.DataService.Application.Mappers
{
    public static class CredentialsDtoBriefMapper
    {

        static CredentialsDtoBriefMapper()
        {
            Mapper.CreateMap<Credentials, CredentialsDtoBrief>();

        }



        public static CredentialsDtoBrief ToDtoBrief(this Credentials Credentials)
        {
            return Mapper.Map<Credentials, CredentialsDtoBrief>(Credentials);
        }


    }
}
