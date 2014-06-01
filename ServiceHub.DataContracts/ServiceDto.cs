using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ServiceHub.DataContracts
{
    [DataContract]
    public class ServiceDto
    {

        [DataMember]
        public int ServiceId { get; private set; }

        [DataMember]
        public string FriendlyName { get; set; }

        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public string ExecutableName { get; set; }
    }
}
