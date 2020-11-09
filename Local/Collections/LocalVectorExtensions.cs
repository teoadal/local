using System;

namespace Local.Collections
{
    public static class LocalVectorExtensions
    {
        public static T Max<T>(this in LocalVector<T> vector)
            where T : IComparable<T>
        {
            var enumerator = vector.GetEnumerator();

            if (!enumerator.MoveNext()) throw CollectionIsEmpty;
            var max = enumerator.Current;

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current.CompareTo(max) == 1)
                {
                    max = current;
                }
            }

            return max;
        }

        public static T Min<T>(this in LocalVector<T> vector)
            where T : IComparable<T>
        {
            var enumerator = vector.GetEnumerator();

            if (!enumerator.MoveNext()) throw CollectionIsEmpty;
            var min = enumerator.Current;

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current.CompareTo(min) == -1)
                {
                    min = current;
                }
            }

            return min;
        }

        private static Exception CollectionIsEmpty => new InvalidOperationException("Collection is empty");
    }
}