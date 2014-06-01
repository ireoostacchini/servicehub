// -----------------------------------------------------------------------
// <copyright file="TestCache.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Ninject;
using ServiceHub.DataAccess;
using ServiceHub.DataAccess.Migrations;
using ServiceHub.DataContracts.Interfaces;
using ServiceHub.DataService.WebAPI.Controllers;
using ServiceHub.Infrastructure;
using ServiceHub.Infrastructure.Interfaces;
using ServiceHub.Model;

namespace ServiceHub.Test.Integration.DataService.WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using ServiceHub.Test.Integration.Helpers;




        [TestFixture]
        public class TestUnitOfWork
        {
            [Test]
            public void Can_read_from_the_database()
            {
                using (var unit = Container.Kernel.Get<IUnitOfWork>())
                {
                    
                    var machines = unit.Machines.GetAll().ToList();

                    Assert.That(machines.Count > 0);
                }
            }

            [Test]
            public void Can_write_to_the_database()
            {
                try
                {


                    using (var unit = Container.Kernel.Get<IUnitOfWork>())
                    {
                        var machine = new Machine() {FriendlyName = "friendly", Name = "name"};

                        unit.Machines.Add(machine);
                        unit.Commit();
                    }


                    //check that we can read the machine back
                    using (var unit = Container.Kernel.Get<IUnitOfWork>())
                    {
                        var machine = unit.Machines.GetAll().FirstOrDefault(x => x.FriendlyName == "friendly");

                        Assert.IsNotNull(machine);

                        Assert.AreEqual(machine.Name, "name");

                    }
                }
                finally
                {
                    //we change DB state inthis test, so we reseed the database
                    DataSeeder.Run();
                }




            }
        }
    }
