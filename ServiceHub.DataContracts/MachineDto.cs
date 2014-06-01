using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ServiceHub.DataContracts
{
    [DataContract]
    public class MachineDto
    {

        [DataMember]
        public int MachineId { get; set; }

        [DataMember,Required]
        public string FriendlyName { get; set; }

        [DataMember,Required]
        public string Name { get; set; }

        [DataMember]
        public int? CredentialsId { get; set; }

        [DataMember]
        public CredentialsDto Credentials { get; set; }

        [DataMember]
        public string Version { get; set; }
    
    }
}
