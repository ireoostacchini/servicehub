using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ServiceHub.DataAccess.Interfaces;
using ServiceHub.Model;



namespace ServiceHub.DataAccess
{
    public class DatabaseManager : IDatabaseManager
    {


        //by default, DB is only created if it doesn't exist
        public void InitializeDatabase()
        {

            using (var context = new Context())
            {
                try
                {
                    context.Database.Initialize(force: false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Initialization Failed...");
                    Console.WriteLine(ex.Message);
                }

            }
        }


    }


}