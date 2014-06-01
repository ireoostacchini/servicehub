// -----------------------------------------------------------------------
// <copyright file="Container.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Ninject;
using ServiceHub.DataService.Application.Interfaces;
using ServiceHub.DataAccess;
using ServiceHub.DataAccess.Interfaces;
using ServiceHub.Infrastructure.Interfaces;
using ServiceHub.Test.Common.Fakes;
using ServiceHub.Test.Fakes;
using ServiceHub.UI.Win;
using ServiceHub.Application;
using ServiceHub.DataContracts.Interfaces;
using ServiceHub.DataService.Application;

namespace ServiceHub.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ServiceHub.Test.Application.Server;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Container
    {
        private static IKernel _kernel ;

        public static void RegisterServices(IKernel kernel)
        {


            _kernel.Bind<IUnitOfWork>().To<FakeUnitOfWork>();

            _kernel.Bind<IData>().To<Data>();



            _kernel.Bind<ILogger>().To<FakeLogger>();
        }

        static Container()
        {

            _kernel = new StandardKernel();

            RegisterServices(_kernel);


        }

        public static IKernel Kernel
        {
            get
            {
                return _kernel;
            }
        }


    }
}
