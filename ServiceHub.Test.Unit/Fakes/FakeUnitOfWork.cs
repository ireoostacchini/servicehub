using ServiceHub.DataAccess;
using ServiceHub.DataAccess.Interfaces;
using ServiceHub.Model;
using ServiceHub.Test.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceHub.Test.Application.Server
{
    class FakeUnitOfWork:IUnitOfWork
    {
        public void Commit()
        {
          
        }

        public void Dispose()
        {
          
        }

        public IRepository<Machine> Machines
        {
            get { return new FakeRepository<Machine>(new FakeContext()); }
        }

        public IRepository<MachineService> MachineServices
        {
            get { return new FakeRepository<MachineService>(new FakeContext()); }
        }

        public IRepository<Service> Services
        {
            get { return new FakeRepository<Service>(new FakeContext()); }
        }

        public IRepository<Credentials> Credentials
        {
            get { return new FakeRepository<Credentials>(new FakeContext()); }
        }
    }
}
