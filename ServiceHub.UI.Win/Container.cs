// -----------------------------------------------------------------------
// <copyright file="Container.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Ninject;
using ServiceHub.Application;
using ServiceHub.Application.Interfaces;
using ServiceHub.DataContracts.Interfaces;
using ServiceHub.Infrastructure;
using ServiceHub.Infrastructure.Interfaces;
using ServiceHub.UI.Interfaces;
using ServiceHub.Application;

namespace ServiceHub.UI.Win
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ServiceHub;
    using Ninject.Extensions.Conventions;


    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Container
    {
        private static IKernel _kernel;

        public static void RegisterServices()
        {
            _kernel.Bind<ILogger>().To<Logger>();

            //binding by convention - https://github.com/ninject/ninject.extensions.conventions/wiki

            BindDefaultInterfaces("ServiceHub.Infrastructure.Interfaces", "ServiceHub.Infrastructure");

            BindDefaultInterfaces("ServiceHub.Application.Interfaces", "ServiceHub.Application");

             //don't know why we can't map ServiceHub.UI.Interfaces to ServiceHub.UI
            _kernel.Bind<IConfig>().To<Config>();

            //bind explicitly to a differently-named assembly
            _kernel.Bind<IData>().To<Data>();
        }

        private static void BindDefaultInterfaces(string interfaceAssembly, string componentAssembly)
        {
            _kernel.Bind(x => x
                .From(interfaceAssembly)
                .SelectAllInterfaces()
                .StartingWith(componentAssembly)
                .BindDefaultInterface()
                );
        }

        static Container()
        {

            _kernel = new StandardKernel();

            RegisterServices();


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
