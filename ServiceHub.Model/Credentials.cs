// -----------------------------------------------------------------------
// <copyright file="Credentials.cs" company="">
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
    public class Credentials
    {
        public int CredentialsId { get; set; }

    
        public string Username { get;  set; }

 
        public string Password{ get;  set; }

        public byte[] RowVersion { get; set; }
    }
}
