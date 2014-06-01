// -----------------------------------------------------------------------
// <copyright file="TestCache.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Ninject;
using ServiceHub.DataContracts.Interfaces;
using ServiceHub.Infrastructure;
using ServiceHub.Infrastructure.Interfaces;

namespace ServiceHub.Test.Integration.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using ServiceHub.Test.Integration.Helpers;




        [TestFixture]
        public class TestLogger
        {
            [Test]
            public void Logger_writes_to_file()
            {
                //this can't actually fail - if the logger fails, it does not throw an exception. 
                //We can use this for manual testing - to see if the log file has been written to

                ILogger logger =  Container.Kernel.Get<ILogger>();

  
                logger.Error("nooo!!", new Exception("something went wrong!"));


            }


        }
    }
