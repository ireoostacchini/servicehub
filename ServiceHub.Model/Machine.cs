using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ServiceHub.Model
{
    public class Machine
    {
        public int MachineId { get; set; }

   
        public string FriendlyName { get;  set; }


        public string Name { get;  set; }

        public int? CredentialsId { get;  set; }
        public Credentials Credentials { get;  set; }

        public byte[] RowVersion { get; set; }

        public virtual ICollection<MachineService> MachineServices { get; set; }
    }
}
