using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHub.DataAccess.Migrations
{
    public class DataSeeder
    {
        public static void Run()
       {
           var context = new Context();

           //TODO: fix - path fails when called via update-database - find a proper fix
           //also, we call this from integration tests

           //this works when the web app is run
           // we need to ensure it ends with a \ - not the case when running integration tests
           var baseDirectory = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + @"\";

           var path = baseDirectory + @"..\data.sql";

           if (!File.Exists(path))
           {
               //but when calling update-database, the BaseDirectory is one folder lower
               path = baseDirectory + @"..\..\data.sql";
           }

           if (!File.Exists(path))
           {
               //and in integration testing, the base is \bin\debug, so we go one more level up. Horrific!
               path = baseDirectory + @"..\..\..\data.sql";
           }


           var sql = File.ReadAllText(path);

           context.Database.ExecuteSqlCommand(sql);
       }
    }
}
