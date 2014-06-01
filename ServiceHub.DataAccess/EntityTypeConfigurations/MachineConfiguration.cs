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
    public class MachineConfiguration: EntityTypeConfiguration<Machine>
    {
        public MachineConfiguration()
        {
            Property(d => d.FriendlyName).IsRequired().HasMaxLength(50);
            Property(d => d.Name).IsRequired().HasMaxLength(20);
            Property(d => d.RowVersion).IsRowVersion();

            HasOptional(d => d.Credentials);
            HasMany(d => d.MachineServices).WithRequired(a => a.Machine);
        }
    }
}
