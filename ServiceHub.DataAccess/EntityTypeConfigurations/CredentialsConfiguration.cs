// -----------------------------------------------------------------------
// <copyright file="MachineConfiguration.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ServiceHub.DataAccess.EntityTypeConfigurations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ServiceHub.Model;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CredentialsConfiguration: EntityTypeConfiguration<Credentials>
    {
        public CredentialsConfiguration()
        {
            Property(d => d.Username).IsRequired().HasMaxLength(50);
            Property(d => d.Password).IsRequired().HasMaxLength(50);

         
        }
    }
}
