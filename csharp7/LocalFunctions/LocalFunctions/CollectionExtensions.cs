using System;
using System.Collections.Generic;
using System.Text;

namespace LocalFunctions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> Filter1<T>(this IEnumerable<T> source, Func<T, bool> pred)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pred == null) throw new ArgumentNullException(nameof(pred));

            foreach (T item in source)
            {
                if (pred(item))
                    yield return item;
            }
        }

        public static IEnumerable<T> Filter2<T>(this IEnumerable<T> source, Func<T, bool> pred)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pred == null) throw new ArgumentNullException(nameof(pred));

            return Filter2Core<T>(source, pred);
        }

        private static IEnumerable<T> Filter2Core<T>(IEnumerable<T> source, Func<T, bool> pred)
        {
            foreach (T item in source)
            {
                if (pred(item))
                    yield return item;
            }
        }

        public static IEnumerable<T> Filter3<T>(this IEnumerable<T> source, Func<T, bool> pred)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pred == null) throw new ArgumentNullException(nameof(pred));

            return Filter3Core();

            IEnumerable<T> Filter3Core()
            {
                foreach (T item in source)
                {
                    if (pred(item))
                        yield return item;
                }
            }
        }

    }
}
