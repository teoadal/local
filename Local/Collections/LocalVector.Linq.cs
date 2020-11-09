using System;
using System.Collections.Generic;

namespace Local.Collections
{
    public ref partial struct LocalVector<T>
    {
        #region All

        public readonly bool All(Func<T, bool> predicate)
        {
            for (var i = 0; i < _length; i++)
            {
                if (!predicate(Get(i)))
                {
                    return false;
                }
            }

            return true;
        }

        public readonly bool All<TArg>(Func<T, TArg, bool> predicate, TArg arg)
        {
            for (var i = 0; i < _length; i++)
            {
                if (!predicate(Get(i), arg))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Any

        public readonly bool Any() => _length > 0;

        public readonly bool Any(Func<T, bool> predicate)
        {
            for (var i = 0; i < _length; i++)
            {
                if (predicate(Get(i)))
                {
                    return true;
                }
            }

            return false;
        }

        public readonly bool Any<TArg>(Func<T, TArg, bool> predicate, TArg arg)
        {
            for (var i = 0; i < _length; i++)
            {
                if (predicate(Get(i), arg))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Count

        public readonly int Count(Func<T, bool> predicate)
        {
            var count = 0;
            for (var i = 0; i < _length; i++)
            {
                if (predicate(Get(i)))
                {
                    count++;
                }
            }

            return count;
        }

        public readonly int Count<TArg>(Func<T, TArg, bool> predicate, TArg arg)
        {
            var count = 0;
            for (var i = 0; i < _length; i++)
            {
                if (predicate(Get(i), arg))
                {
                    count++;
                }
            }

            return count;
        }

        #endregion

        #region First

        public readonly T First()
        {
            EnsureNotEmpty();
            return _element0;
        }

        public readonly T First(Func<T, bool> predicate)
        {
            for (var i = 0; i < _length; i++)
            {
                var element = Get(i);
                if (predicate(element))
                {
                    return element;
                }
            }

            throw new InvalidOperationException("Element isn't found");
        }

        public readonly T First<TArg>(Func<T, TArg, bool> predicate, TArg arg)
        {
            for (var i = 0; i < _length; i++)
            {
                var element = Get(i);
                if (predicate(element, arg))
                {
                    return element;
                }
            }

            throw new InvalidOperationException("Element isn't found");
        }

        #endregion

        public readonly T Last()
        {
            EnsureNotEmpty();
            return Get(_length - 1);
        }

        public LocalVector<T> OrderBy<TProperty>(Func<T, TProperty> property, Comparer<TProperty>? comparer = null)
        {
            Sort(property, comparer);
            return this;
        }

        #region Select

        public readonly LocalVector<TValue> Select<TValue>(Func<T, TValue> selector)
        {
            var result = new LocalVector<TValue>(_length);

            for (var i = 0; i < _length; i++)
            {
                var element = Get(i);
                result.Add(selector(element));
            }

            return result;
        }

        public readonly LocalVector<TValue> Select<TValue, TArg>(Func<T, TArg, TValue> selector, TArg arg)
        {
            var result = new LocalVector<TValue>(_length);

            for (var i = 0; i < _length; i++)
            {
                var element = Get(i);
                result.Add(selector(element, arg));
            }

            return result;
        }

        #endregion

        #region Where

        public readonly LocalVector<T> Where(Func<T, bool> predicate)
        {
            var result = new LocalVector<T>();

            for (var i = 0; i < _length; i++)
            {
                var element = Get(i);
                if (predicate(element))
                {
                    result.Add(element);
                }
            }

            return result;
        }

        public readonly LocalVector<T> Where<TArg>(Func<T, TArg, bool> predicate, TArg arg)
        {
            var result = new LocalVector<T>();

            for (var i = 0; i < _length; i++)
            {
                var element = Get(i);
                if (predicate(element, arg))
                {
                    result.Add(element);
                }
            }

            return result;
        }

        #endregion
    }
}