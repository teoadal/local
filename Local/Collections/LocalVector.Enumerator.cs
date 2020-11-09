namespace Local.Collections
{
    public ref partial struct LocalVector<T>
    {
        public ref struct Enumerator
        {
            public readonly T Current => _vector.Get(_position);

            public readonly int Length;

            private int _position;
            private readonly LocalVector<T> _vector;

            internal Enumerator(in LocalVector<T> vector)
            {
                Length = vector._length;

                _position = -1;
                _vector = vector;
            }

            public bool MoveNext()
            {
                _position++;
                return _position < Length;
            }
        }
    }
}