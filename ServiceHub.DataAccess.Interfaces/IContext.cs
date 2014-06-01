using ServiceHub.Model;
using System;
using System.Data.Entity;

namespace ServiceHub.DataAccess.Interfaces
{
   public interface IContext
    {
        IDbSet<Credentials> Credentials { get; set; }
        IDbSet<Machine> Machines { get; set; }
        IDbSet<MachineService> MachineServices { get; set; }
        IDbSet<Service> Services { get; set; }

        IDbSet<T> Set<T>() where T : class;
    }
}
