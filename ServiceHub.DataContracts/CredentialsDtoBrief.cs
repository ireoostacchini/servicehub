using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ServiceHub.DataContracts
{
    [DataContract]
    public class CredentialsDtoBrief
    {
        //a version of CredentialsDto without the password - safe for passing to the admin web site


        [DataMember, Required]
        public int CredentialsId { get; set; }

        [DataMember,Required]
        public string Username { get; set; }


    }
}
