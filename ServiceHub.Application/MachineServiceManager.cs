using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.ServiceProcess;
using System.Diagnostics;
using ServiceHub.Application.Interfaces;
using ServiceHub.DataContracts;
using ServiceHub.Infrastructure;
using ServiceHub.Infrastructure.Interfaces;


namespace ServiceHub.Application
{
    public class MachineServiceManager : IMachineServiceManager
    {
        public MachineServiceDto MachineService { get; set; }

        private bool? _serviceExists = null;
        private ILogger _logger;


        public MachineServiceManager(MachineServiceDto machineService, ILogger logger)
        {

            MachineService = machineService;
            _logger = logger;
        }


        public void Stop()
        {

            //eg pskill -t \\pc8  armsvc.exe -u Ireo -p myPassword

            if (ServiceExists() == false) return;

            ProcessStartInfo startInfo = new ProcessStartInfo("PSTools\\pskill.exe");

            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "-t \\\\" + MachineService.Machine.Name + " " + MachineService.Service.ExecutableName + GetCredentials();
            startInfo.Verb = "runas";
            startInfo.UseShellExecute = false;      //see http://msdn.microsoft.com/en-us/library/system.diagnostics.processstartinfo.useshellexecute.aspx
            startInfo.CreateNoWindow = true;

            var proc = Process.Start(startInfo);

            proc.WaitForExit();


        }

        public void Start()
        {

            //eg  psservice \\pc8 start "Adobe Acrobat Update Service" start

            if (ServiceExists() == false) return ;

            ProcessStartInfo startInfo = new ProcessStartInfo("PSTools\\psservice.exe");

            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "\\\\" + MachineService.Machine.Name + " start \"" + MachineService.Service.ServiceName + "\"" + GetCredentials();
            startInfo.Verb = "runas";
            startInfo.UseShellExecute = false;      //see http://msdn.microsoft.com/en-us/library/system.diagnostics.processstartinfo.useshellexecute.aspx
            startInfo.CreateNoWindow = true;

            var proc = Process.Start(startInfo);

            proc.WaitForExit();


        }

        private string GetCredentials()
        {
            var result = string.Empty;

            if (MachineService.Machine.Credentials != null)
            {
                var password = Encryptor.Decrypt(MachineService.Machine.Credentials.Password);

                result = " -u " + MachineService.Machine.Credentials.Username + " -p " + password;
            }

            return result;
        }

        public IMachineServiceStatus GetStatus()
        {

            if (ServiceExists() == false) return MachineServiceStatus.NotFound;      

            using (var serviceController = new ServiceController(MachineService.Service.ServiceName, MachineService.Machine.Name))
            {

                return MachineServiceStatus.Find( (int)serviceController.Status);
              
            }
        }

        //we run this only once for each service - stops us calling GetStatus on a servcie that doesn't exist (that causes pskill / psservice to stay open)
        public bool ServiceExists()
        {
            if (_serviceExists.HasValue) return _serviceExists.Value;

            using (var serviceController = new ServiceController(MachineService.Service.ServiceName, MachineService.Machine.Name))
            {
                try
                {
                    var x = serviceController.Status;

                    _serviceExists = true;
                    return true;
                }
                catch (InvalidOperationException ex)
                {
                    var message = string.Format("Service {0}.{1} does not exist.", MachineService.Machine.Name, MachineService.Service.ServiceName );

                  _logger.Error(message);

                    _serviceExists = false;
                    return false;
                }


            }


        }

        
    

    }
}
