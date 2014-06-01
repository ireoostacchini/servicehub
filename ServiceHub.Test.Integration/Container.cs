// -----------------------------------------------------------------------
// <copyright file="Container.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Ninject;
using ServiceHub.DataService.Application.Interfaces;
using ServiceHub.DataAccess;
using ServiceHub.DataAccess.Interfaces;
using ServiceHub.DataService.WebAPI.Controllers;
using ServiceHub.Infrastructure;
using ServiceHub.Infrastructure.Interfaces;
using ServiceHub.Test.Common.Fakes;
using ServiceHub.UI.Win;
using ServiceHub.DataContracts.Interfaces;
using ServiceHub.DataService.Application;

namespace ServiceHub.Test.Integration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Container
    {
        private static IKernel _kernel ;

        public static void RegisterServices(IKernel kernel)
        {

            _kernel.Bind<MachinesController>().To<MachinesController>();

            _kernel.Bind<IDatabaseManager>().To<DatabaseManager>();

            _kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            _kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

  

            _kernel.Bind<ILogger>().To<FakeLogger>();
    
            _kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>()
                .WithConstructorArgument("repositoryFactories", new RepositoryFactories());
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
