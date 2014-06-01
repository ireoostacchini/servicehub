using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ServiceHub.DataContracts
{
    [DataContract]
    public class MachineServiceDto
    {

        [DataMember]
        public int MachineServiceId { get; set; }

        [DataMember]
        public int MachineId { get; set; }

        [DataMember]
        public int ServiceId { get; set; }

        [DataMember]
        public int? Status { get; set; }

        [DataMember]
        public MachineDto Machine { get; set; }
        
        [DataMember]
        public ServiceDto Service { get; set; }
    }
}
