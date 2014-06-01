using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using ServiceHub.DataContracts;
using ServiceHub.DataContracts.Interfaces;

namespace ServiceHub.Application
{



    public class Data : IData
    {
        static List<MachineDto> _machines;
        static List<ServiceDto> _services;
        static List<MachineServiceDto> _machineServices;
        static List<CredentialsDto> _credentials;

        public List<MachineDto> Machines
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
        public List<ServiceDto> Services
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

        public List<MachineServiceDto> MachineServices
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


        public List<CredentialsDto> Credentials
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
}
}