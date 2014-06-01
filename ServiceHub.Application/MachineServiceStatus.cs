using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceHub.Application.Interfaces;

namespace ServiceHub.Application
{

    /// <summary>
    /// Effectively an extension of ServiecControllerStatus, adding a 'Not Found' status
    /// http://msdn.microsoft.com/en-us/library/system.serviceprocess.servicecontrollerstatus.aspx
    /// </summary>
    public class MachineServiceStatus : IMachineServiceStatus
    {

        private static List<MachineServiceStatus> _statuses;

        static MachineServiceStatus()
        {
            _statuses = new List<MachineServiceStatus>(){

            new MachineServiceStatus (){Id=0, Name= "Not Found"},
            new MachineServiceStatus (){Id=1, Name= "Stopped"},
            new MachineServiceStatus (){Id=2, Name="Start Pending"},
            new MachineServiceStatus (){Id=3, Name= "Stop Pending"},
            new MachineServiceStatus (){Id=4, Name="Running"},
            new MachineServiceStatus (){Id=5, Name= "Continue Pending"},
            new MachineServiceStatus (){Id=6, Name="Pause Pending"},
            new MachineServiceStatus (){Id=7, Name="Paused"}
           };

        }

        public static MachineServiceStatus NotFound {get{return Find(0);}}
        public static MachineServiceStatus Stopped { get { return Find(1); } }
        public static MachineServiceStatus StartPending { get { return Find(2); } }
        public static MachineServiceStatus StopPending { get { return Find(3); } }
        public static MachineServiceStatus Running { get { return Find(4); } }
        public static MachineServiceStatus ContinuePending { get { return Find(5); } }
        public static MachineServiceStatus PausePending { get { return Find(6); } }
        public static MachineServiceStatus Paused { get { return Find(7); } }

        public static MachineServiceStatus Find(int id)
        {
            return _statuses.First(x => x.Id == id);
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
