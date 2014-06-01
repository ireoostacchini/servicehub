using ServiceHub.DataContracts.Interfaces;
using ServiceHub.DataService.Application.Interfaces;
using ServiceHub.DataAccess;
using ServiceHub.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace ServiceHub.Test.Integration.Helpers
{
   internal static class DataLoader
    {

       internal static void LoadData(IData data)
       {
           using (var unitOfWork = Container.Kernel.Get<UnitOfWork>())
           {


               var dataProvider = Container.Kernel.Get<IDataProvider>();

               dataProvider.LoadData(data, unitOfWork);

           }
       }


      

    }
}
