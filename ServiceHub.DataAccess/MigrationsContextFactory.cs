using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;

namespace ServiceHub.DataAccess
{

    /// <summary>
    /// This is purely for use with EF migrations
    /// - see http://stackoverflow.com/questions/11395283/how-to-implement-idbcontextfactory-for-use-with-entity-framework-data-migrations
    /// </summary>
    public class MigrationsContextFactory : IDbContextFactory<Context>
    {
        public Context Create()
        {
            //can't see a way to inject the database name, so it's hard-coded

            return new Context();
        }
    }
}
