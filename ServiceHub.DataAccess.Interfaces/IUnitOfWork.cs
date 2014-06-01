using System;
using ServiceHub.DataAccess.Interfaces;
using ServiceHub.Model;

namespace ServiceHub.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Dispose();
        IRepository<Machine> Machines { get; }
        IRepository<MachineService> MachineServices { get; }
        IRepository<Service> Services { get; }
        IRepository<Credentials> Credentials { get; }
    }
}
