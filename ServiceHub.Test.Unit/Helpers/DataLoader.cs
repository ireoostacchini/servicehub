using ServiceHub.DataContracts.Interfaces;
using ServiceHub.DataService.Application.Interfaces;
using ServiceHub.DataAccess;
using ServiceHub.Model;
using ServiceHub.Test.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using ServiceHub.Test.Application.Server;

namespace ServiceHub.Test.Unit.Helpers
{
    internal static class DataLoader
    {



        internal static void LoadData(IData data, IUnitOfWork unitOfWork)
        {


            //****************************services
            var services = (FakeRepository<Service>)unitOfWork.Services;

            var service1 = new Service() { ServiceId = 1, FriendlyName = "serv1", ExecutableName = "s1", ServiceName = "ss1" };
            var service2 = new Service() { ServiceId = 2, FriendlyName = "serv2", ExecutableName = "s2", ServiceName = "ss2" };

            services.Add(service1);
            services.Add(service2);

            //****************************machines
            var machines = (FakeRepository<Machine>)unitOfWork.Machines;

            var machine1 = new Machine() { MachineId = 1, Name = "mach1", FriendlyName = "mach1" };
            var machine2 = new Machine() { MachineId = 2, Name = "mach2", FriendlyName = "mach2" };


            machines.Add(machine1);
            machines.Add(machine2);

            //****************************credentials
            var credentials = (FakeRepository<Credentials>)unitOfWork.Credentials;
            var cred1 = new Credentials() { CredentialsId = 1, Username = "u", Password = "pwd" };

            credentials.Add(cred1);


            //****************************relationships
            machine1.Credentials = cred1;
            machine1.CredentialsId = cred1.CredentialsId;

            var machineServices = (FakeRepository<MachineService>)unitOfWork.MachineServices;

            var ms1 = new MachineService()
            {
                MachineServiceId = 1,
                MachineId = 1,
                Machine = machine1,
                ServiceId =1,
                Service = service1
            };
            var ms2 = new MachineService()
            {
                MachineServiceId = 2,
                MachineId = 1,
                Machine = machine1,
                ServiceId = 2,
                Service = service2
            };
            var ms3 = new MachineService()
            {
                MachineServiceId = 3,
                MachineId = 2,
                Machine = machine2,
                ServiceId = 1,
                Service = service1
            };
            
            machineServices.Add(ms1);
            machineServices.Add(ms2);
            machineServices.Add(ms3);
        }

    }
}
