using System;
using System.Collections.Generic;
using ServiceHub.DataContracts;

namespace ServiceHub.DataContracts.Interfaces
{
  public  interface IData
    {
        List<MachineDto> Machines { get; set; }
        List<MachineServiceDto> MachineServices { get; set; }
       List<ServiceDto> Services { get; set; } 
      List<CredentialsDto> Credentials { get; set; }
    }
}
