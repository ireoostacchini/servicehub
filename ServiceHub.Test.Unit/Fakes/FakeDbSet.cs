using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHub.Test.Fakes
{
    internal class FakeDbSet<T, TKey> : IDbSet<T> where T : class
    {

        readonly Func<T, TKey> _keySelector;

        readonly HashSet<T> _hash;

        readonly IQueryable _query;

        public FakeDbSet(Func<T, TKey> keySelector)
        {

            _hash = new HashSet<T>();

            _query = _hash.AsQueryable();

            _keySelector = keySelector;

        }





        public T Find(params object[] keyValues)
        {

            var value = keyValues.First();

            return this.SingleOrDefault(item => _keySelector(item).Equals(value));

        }



        public void RemoveMatch(T entity)
        {

            if (_keySelector(entity).Equals(default(TKey)))
            {

                return;

            }

            this.Remove(Find(_keySelector(entity)));

        }









        public T Add(T entity)
        {

            RemoveMatch(entity);

            _hash.Add(entity);

            return entity;

        }



        public T Attach(T entity)
        {

            RemoveMatch(entity);

            _hash.Add(entity);

            return entity;

        }



        public TDerivedEntity Create<TDerivedEntity>()

        where TDerivedEntity : class, T
        {

            return typeof(TDerivedEntity) as TDerivedEntity;

        }



        public T Create()
        {

            return typeof(T) as T;

        }







        public ObservableCollection<T> Local
        {

            get
            {

                throw new NotImplementedException("Must override Local");

            }

        }



        public T Remove(T entity)
        {

            _hash.Remove(entity);

            return entity;

        }



        public IEnumerator<T> GetEnumerator()
        {

            return _hash.GetEnumerator();

        }



        IEnumerator IEnumerable.GetEnumerator()
        {

            return _hash.GetEnumerator();

        }



        public Type ElementType
        {

            get { return _query.ElementType; }

        }



        public Expression Expression
        {

            get { return _query.Expression; }

        }



        public IQueryProvider Provider
        {

            get { return _query.Provider; }

        }



    }
}
