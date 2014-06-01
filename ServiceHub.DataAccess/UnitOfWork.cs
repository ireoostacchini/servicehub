using System;
using ServiceHub.Model;
using ServiceHub.DataAccess.Interfaces;


namespace ServiceHub.DataAccess
{
    /// <summary>
    /// The "Unit of Work"
    ///     1) decouples the repos from the controllers
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages the UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a <see cref="Person"/>.
    /// A repository typically exposes "Get" methods for querying and
    /// will offer add, update, and delete methods if those features are supported.
    /// The repositories rely on their parent UoW to provide the interface to the
    /// data layer (which is the EF DbContext in Code Camper).
    /// </remarks>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
      
        public UnitOfWork(IRepositoryProvider repositoryProvider)
        {
       

            CreateContext();

            repositoryProvider.Context = Context;
            RepositoryProvider = repositoryProvider;       
        }

        // repositories

        public IRepository<Machine> Machines { get { return GetStandardRepo<Machine>(); } }
        public IRepository<Service> Services { get { return GetStandardRepo<Service>(); } }
        public IRepository<MachineService> MachineServices { get { return new MachineServiceRepository(Context); } }
        public IRepository<Credentials> Credentials { get { return GetStandardRepo<Credentials>(); } }


        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            Context.SaveChanges();
        }

        protected void CreateContext()
        {
            Context = new Context();


        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private Context Context { get; set; }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                }
            }
        }

        #endregion
    }
}