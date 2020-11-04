using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P27.Course.IteratorPattern.Show
{
    public static class LinqExtend
    {
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new Exception("no source");
            }

            if (predicate == null)
            {
                throw new Exception("no predicate");
            }

            EnumeratorIterator<TSource> res = new EnumeratorIterator<TSource>(source,predicate);
            return res;
        }


    }



    public class EnumeratorIterator<TSource> : IEnumerable<TSource>
    {
        private IEnumerable<TSource> source;
        private Func<TSource, bool> predicate;

        public EnumeratorIterator(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            this.source = source;
            this.predicate = predicate;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            foreach (TSource item in this.source)
            {
                if (predicate(item))
                {
                    if (predicate(item))
                        yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (TSource item in this.source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }

        }


    }



}
