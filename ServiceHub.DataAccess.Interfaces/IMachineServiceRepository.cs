using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ServiceHub.DataAccess;
using ServiceHub.Model;

namespace ServiceHub.DataAccess.Interfaces
{
    public interface IMachineServiceRepository :IRepository<MachineService> 
    {
        IQueryable<MachineService> GetAll();
        MachineService GetById(int id);

  
     
    }
}
