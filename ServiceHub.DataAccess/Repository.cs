// -----------------------------------------------------------------------
// <copyright file="Repository.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ServiceHub.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using ServiceHub.DataAccess.Interfaces;



    /// <summary>
    /// The EF-dependent, generic repository for data access
    /// </summary>
    /// <typeparam name="T">Type of entity for this Repository.</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected IContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        //derived repositories somehow require this, other wise we get a compilation failure 
        public Repository()
        {
        }

        public Repository(IContext context)
        {
            if (context == null) throw new ArgumentNullException("dbContext");

            DbSet = context.Set<T>();

            Context = context;

    
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(int id)
        {

            return DbSet.Find(id);
        }
        public T Add(T entity)
        {
            DbSet.Add(entity);

            return entity;
        }

        public void Delete(T entity)
        {
            //we could use Delete(int id) but that's no help with REST APIs
            //where you check for the entity's existence before deleting it

             DbSet.Remove(entity);
         }
      }
}


