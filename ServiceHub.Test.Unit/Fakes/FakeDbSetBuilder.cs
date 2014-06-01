using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHub.Test.Fakes
{

    internal static class FakeDbSetBuilder
    {

        public static FakeDbSetBuilder<T> New<T>() where T : class
        {

            return new FakeDbSetBuilder<T>();

        }

    }



    internal class FakeDbSetBuilder<T> where T : class
    {

        public FakeDbSet<T, TKey> Build<TKey>(Func<T, TKey> keySelector)
        {

            return new FakeDbSet<T, TKey>(keySelector);

        }

    }
}

