using ServiceHub.DataService.Application;
using ServiceHub.DataService.Application.Interfaces;

using Ninject.Extensions.Conventions;

[assembly: WebActivator.PreApplicationStartMethod(typeof(ServiceHub.DataService.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(ServiceHub.DataService.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace ServiceHub.DataService.WebAPI.App_Start
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Http;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

 
    using ServiceHub.DataAccess;
    using ServiceHub.DataAccess.Interfaces;
    using ServiceHub.DataService.WebAPI.Helpers;
    using ServiceHub.DataContracts.Interfaces;
    using ServiceHub.Infrastructure.Interfaces;
    using ServiceHub.Infrastructure;


    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);

            //from http://www.strathweb.com/2012/05/using-ninject-with-the-latest-asp-net-web-api-source/
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(CreateKernel());
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            
            kernel.Bind<IDatabaseManager>().To<DatabaseManager>();

           kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));

           kernel.Bind<IUnitOfWork>().To<UnitOfWork>();




            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>()
                .WithConstructorArgument("repositoryFactories", new RepositoryFactories());

            kernel.Bind<ILogger>().To<Logger>();


 

            //TODO: make convention binding work...
           //BindDefaultInterfaces(kernel, "ServiceHub.Infrastructure.Interfaces", "ServiceHub.Infrastructure");

           // BindDefaultInterfaces(kernel, "ServiceHub.Application.Server.Interfaces", "ServiceHub.Application.Server");

            //BindDefaultInterfaces(kernel, "ServiceHub.DataAccess.Interfaces", "ServiceHub.DataAccess");



        }


        private static void BindDefaultInterfaces(IKernel kernel, string interfaceAssembly, string componentAssembly)
        {
            kernel.Bind(x => x
                .From(interfaceAssembly)
                .SelectAllInterfaces()
                .StartingWith(componentAssembly)
                .BindDefaultInterface()
                );
        }
    }
}
