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
    public class MachineServiceConfiguration: EntityTypeConfiguration<MachineService>
    {
        public MachineServiceConfiguration()
        {
            Property(d => d.MachineId).IsRequired();
            Property(d => d.ServiceId).IsRequired();
           
        }
    }
}
