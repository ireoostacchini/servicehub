// -----------------------------------------------------------------------
// <copyright file="Service.cs" company="">
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
    public class Service
    {
        public int ServiceId { get; set; }


        public string FriendlyName { get;  set; }

  
        public string ServiceName { get;  set; }

  
        public string ExecutableName { get;  set; }


        public byte[] RowVersion { get; set; }
    }
}
