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
    public class ServiceConfiguration: EntityTypeConfiguration<Service>
    {
        public ServiceConfiguration()
        {
            Property(d => d.FriendlyName).IsRequired().HasMaxLength(50);
            Property(d => d.ServiceName).IsRequired().HasMaxLength(250);
            Property(d => d.ExecutableName).IsRequired().HasMaxLength(250);

        }
    }
}
