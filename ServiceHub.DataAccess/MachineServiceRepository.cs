// -----------------------------------------------------------------------
// <copyright file="Repository.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ServiceHub.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using ServiceHub.DataAccess.Interfaces;
    using ServiceHub.Model;




    public class MachineServiceRepository : Repository<MachineService>, IMachineServiceRepository
    {

        private IQueryable<MachineService> _query;


        public MachineServiceRepository(Context context)
        {
            if (context == null) throw new ArgumentNullException("dbContext");

            DbSet = context.Set<MachineService>();
                
            _query =   DbSet.Include(x=>x.Machine).Include(x=>x.Service).Include(x=>x.Machine.Credentials);

            Context = context;

    
        }

        public override IQueryable<MachineService> GetAll()
        {
            return _query;
        }

        public override MachineService GetById(int id)
        {

            return _query.FirstOrDefault<MachineService>(x=>x.MachineServiceId == id);
        }

      }
}


