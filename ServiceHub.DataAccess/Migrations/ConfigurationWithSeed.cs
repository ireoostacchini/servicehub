using System.IO;

namespace ServiceHub.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationWithSeed : DbMigrationsConfiguration<ServiceHub.DataAccess.Context>
    {
        public ConfigurationWithSeed()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ServiceHub.DataAccess.Context context)
        {
           DataSeeder.Run();
        }

       
    }
}
