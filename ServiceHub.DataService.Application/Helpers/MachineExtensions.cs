using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ServiceHub.DataContracts;
using ServiceHub.Model;

namespace ServiceHub.DataService.Application.Helpers
{
    public static class MachineExtensions
    {
        public static void Update(this Machine machine, MachineDto dto)
        {
            machine.Name = dto.Name;

            machine.FriendlyName = dto.FriendlyName;

            machine.CredentialsId = dto.CredentialsId;

        }

    }
}