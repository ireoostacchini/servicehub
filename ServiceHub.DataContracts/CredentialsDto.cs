using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ServiceHub.DataContracts
{
    [DataContract]
    public class CredentialsDto
    {
        [DataMember, Required]
        public int CredentialsId { get; set; }

        [DataMember,Required]
        public string Username { get; set; }

        [DataMember,Required]
        public string Password { get; set; }
    }
}
