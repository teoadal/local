using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Local.Collections
{
    public ref partial struct LocalVector<T>
    {
        private const int Capacity = 7;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public readonly int Length => _length;

        private T _element0;
        private T _element1;
        private T _element2;
        private T _element3;
        private T _element4;
        private T _element5;
        private T _element6;
        private T[]? _array;

        private int _length;

        #region Constructors

        public LocalVector(int capacity = 0)
        {
            _element0 = default!;
            _element1 = default!;
            _element2 = default!;
            _element3 = default!;
            _element4 = default!;
            _element5 = default!;
            _element6 = default!;

            _array = capacity > Capacity ? new T[capacity - Capacity] : null;

            _length = 0;
        }

        public LocalVector(T item0)
            : this(1)
        {
            _element0 = item0;

            _length = 1;
        }

        public LocalVector(T item0, T item1)
            : this(2)
        {
            _element0 = item0;
            _element1 = item1;

            _length = 2;
        }

        public LocalVector(T item0, T item1, T item2)
            : this(3)
        {
            _element0 = item0;
            _element1 = item1;
            _element2 = item2;

            _length = 3;
        }

        public LocalVector(T item0, T item1, T item2, T item3)
            : this(4)
        {
            _element0 = item0;
            _element1 = item1;
            _element2 = item2;
            _element3 = item3;

            _length = 4;
        }

        public LocalVector(T item0, T item1, T item2, T item3, T item4)
            : this(5)
        {
            _element0 = item0;
            _element1 = item1;
            _element2 = item2;
            _element3 = item3;
            _element4 = item4;

            _length = 5;
        }

        public LocalVector(IEnumerable<T> collection) : this()
        {
            foreach (var element in collection)
            {
                Add(element);
            }
        }

        public LocalVector(ICollection<T> collection) : this(collection.Count)
        {
            foreach (var element in collection)
            {
                Add(element);
            }
        }

        public LocalVector(T[] array) : this(array.Length)
        {
            foreach (var element in array)
            {
                Add(element);
            }
        }

        #endregion

        public void Add(T element)
        {
            switch (_length)
            {
                case 0:
                    _element0 = element;
                    break;
                case 1:
                    _element1 = element;
                    break;
                case 2:
                    _element2 = element;
                    break;
                case 3:
                    _element3 = element;
                    break;
                case 4:
                    _element4 = element;
                    break;
                case 5:
                    _element5 = element;
                    break;
                case 6:
                    _element6 = element;
                    break;
                case Capacity:
                    _array ??= new T[4];
                    _array[0] = element;
                    break;
                default:
                    CollectionUtils.Insert(ref _array!, _length - Capacity, element);
                    break;
            }

            _length++;
        }

        #region AddRange

        public void AddRange(IEnumerable<T> elements)
        {
            foreach (var element in elements)
            {
                Add(element);
            }
        }

        public void AddRange(T[] elements)
        {
            EnsureCapacity(_length + elements.Length);

            foreach (var element in elements)
            {
                Add(element);
            }
        }

        public void AddRange(ICollection<T> elements)
        {
            EnsureCapacity(_length + elements.Count);

            foreach (var element in elements)
            {
                Add(element);
            }
        }

        #endregion

        public void Clear()
        {
            _length = 0;
        }

        public readonly bool Contains(T element, EqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;

            for (var i = 0; i < _length; i++)
            {
                if (comparer.Equals(Get(i), element))
                {
                    return true;
                }
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Enumerator GetEnumerator() => new Enumerator(in this);

        public void Reverse()
        {
            if (_length <= 1) return;

            var start = 0;
            var end = _length - 1;

            while (start < end)
            {
                var tmp = Get(start);

                Set(start, Get(end));
                Set(end, tmp);

                start++;
                end--;
            }
        }

        #region Sort

        public void Sort(Comparer<T>? comparer = null)
        {
            comparer ??= Comparer<T>.Default;

            var border = _length - 1;
            for (var i = 0; i < border; i++)
            {
                var final = false;
                for (var j = 0; j < border - i; j++)
                {
                    var current = Get(j);
                    var nextIndex = j + 1;
                    var next = Get(nextIndex);

                    if (comparer.Compare(next, current) != -1) continue;

                    final = true;
                    Set(nextIndex, current);
                    Set(j, next);
                }

                if (!final) break;
            }
        }

        public void Sort<TProperty>(Func<T, TProperty> property, Comparer<TProperty>? comparer = null)
        {
            comparer ??= Comparer<TProperty>.Default;

            var border = _length - 1;
            for (var i = 0; i < border; i++)
            {
                var final = false;
                for (var j = 0; j < border - i; j++)
                {
                    var current = Get(j);
                    var nextIndex = j + 1;
                    var next = Get(nextIndex);

                    if (comparer.Compare(property(next), property(current)) != -1) continue;

                    final = true;
                    Set(nextIndex, current);
                    Set(j, next);
                }

                if (!final) break;
            }
        }

        #endregion

        public readonly T[] ToArray()
        {
            if (_length == 0) return Array.Empty<T>();

            var result = new T[_length];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = Get(i);
            }

            return result;
        }

        public readonly T this[int index]
        {
            get
            {
                if (index >= _length) throw new ArgumentOutOfRangeException(nameof(index));
                return Get(index);
            }
        }

        private readonly T Get(int index)
        {
            // ReSharper disable once ConvertSwitchStatementToSwitchExpression
            switch (index)
            {
                case 0:
                    return _element0;
                case 1:
                    return _element1;
                case 2:
                    return _element2;
                case 3:
                    return _element3;
                case 4:
                    return _element4;
                case 5:
                    return _element5;
                case 6:
                    return _element6;
                default:
                    return _array![index - Capacity];
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EnsureCapacity(int capacity)
        {
            if (capacity <= _length || capacity < Capacity) return;
            if (_array == null) _array = new T[capacity - Capacity];
            else CollectionUtils.EnsureCapacity(ref _array, capacity - Capacity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly void EnsureNotEmpty()
        {
            if (_length == 0) throw new InvalidOperationException("Collection is empty");
        }

        private void Set(int index, T value)
        {
            switch (index)
            {
                case 0:
                    _element0 = value;
                    return;
                case 1:
                    _element1 = value;
                    return;
                case 2:
                    _element2 = value;
                    return;
                case 3:
                    _element3 = value;
                    return;
                case 4:
                    _element4 = value;
                    return;
                case 5:
                    _element5 = value;
                    return;
                case 6:
                    _element6 = value;
                    return;
                default:
                    _array![index - Capacity] = value;
                    return;
            }
        }
    }
}