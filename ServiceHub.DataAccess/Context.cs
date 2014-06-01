using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using ServiceHub.Model;
using ServiceHub.DataAccess.EntityTypeConfigurations;
using System.Data.Entity.ModelConfiguration.Conventions;

using ServiceHub.DataAccess.Interfaces;

namespace ServiceHub.DataAccess
{
    public class Context : DbContext, IContext
    {

        public Context()
        {
            // Do NOT enable proxied entities, else serialization fails
            Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.

        }




        public IDbSet<Machine> Machines { get; set; }
        public IDbSet<Service> Services { get; set; }
        public IDbSet<Credentials> Credentials { get; set; }
        public IDbSet<MachineService> MachineServices { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .Add(new MachineConfiguration())
                .Add(new ServiceConfiguration())
                .Add(new MachineServiceConfiguration())
                 .Add(new CredentialsConfiguration());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();



        }


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
