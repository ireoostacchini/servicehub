// -----------------------------------------------------------------------
// <copyright file="MachineService.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ServiceHub.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MachineService
    {
        public int MachineServiceId { get; set; }

        public int MachineId { get;  set; }
        public int ServiceId { get;  set; }
     

        public Machine Machine { get;  set; }
        public Service Service { get;  set; }
    }
}
