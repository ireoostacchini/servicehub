using ServiceHub.DataAccess.Interfaces;
using ServiceHub.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceHub.Test.Fakes;



namespace ServiceHub.Test.Fakes
{
    internal class FakeContext : IContext
    {
        private static IDbSet<Credentials> _credentials = FakeDbSetBuilder.New<Credentials>().Build(m => m.CredentialsId);
        private static IDbSet<Machine> _machines = FakeDbSetBuilder.New<Machine>().Build(m => m.MachineId);
        private static IDbSet<Service> _services = FakeDbSetBuilder.New<Service>().Build(x => x.ServiceId);
        private static IDbSet<MachineService> _machineServices = FakeDbSetBuilder.New<MachineService>().Build(x => x.MachineServiceId);

        private static List<object> _sets = new List<object>();


        static FakeContext()
        {
            _sets.Add(_credentials);
            _sets.Add(_services);
            _sets.Add(_machines);
            _sets.Add(_machineServices);
        }


        public IDbSet<Credentials> Credentials
        {
            get
            {
                return _credentials;
            }
            set
            {
                _credentials = value;
            }
        }

        public IDbSet<Machine> Machines
        {
            get
            {
                return _machines;
            }
            set
            {
                _machines = value;
            }
        }

        public IDbSet<Service> Services
        {
            get
            {
                return _services;
            }
            set
            {
                _services = value;
            }
        }

        public IDbSet<MachineService> MachineServices
        {
            get
            {
                return _machineServices;
            }
            set
            {
                _machineServices = value;
            }
        }


        public IDbSet<T> Set<T>() where T : class
        {

            foreach (object set in _sets)
            {

                try
                {
                    return (IDbSet<T>)set;

                }
                catch
                {
                    //do nothing - go through all the sets - if there is no set for this eneity, throw the exception below
                }

            }

            throw new Exception("IDbSet not found for entity type " + typeof(T).ToString());
        }
    }
}
