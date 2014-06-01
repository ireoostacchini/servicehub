using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceHub.DataAccess.Interfaces;
using System.Data.Entity;

namespace ServiceHub.Test.Fakes
{
    internal class FakeRepository<T> : IRepository<T> where T : class
    {
        public IContext Context { get; set; }

        public IDbSet<T> DbSet { get; set; }



        public FakeRepository(IContext context)
        {
            if (context == null) throw new ArgumentNullException("dbContext");

            DbSet = context.Set<T>();

            Context = context;


        }


        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }


        //this allows us to get fake data into the repository / context
        public T Add(T entity)
        {
            return DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);



        }
    }
}
