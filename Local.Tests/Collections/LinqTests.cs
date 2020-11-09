using System;
using Xunit;

namespace Local.Tests.Collections
{
    public class LinqTests
    {
        public static TheoryData<Foo[]> FooItems = new TheoryData<Foo[]>
        {
            Array.Empty<Foo>(),
            new[] {new Foo(1)},
            new[] {new Foo(1), new Foo(1)},
            new[] {new Foo(1), new Foo(2)},
            new[] {new Foo(2), new Foo(1), new Foo(1)},
            new[] {new Foo(1), new Foo(1), new Foo(2)},
            new[] {new Foo(1), new Foo(1), new Foo(2), new Foo(5), new Foo(6), new Foo(7)},
            new[]
            {
                new Foo(1), new Foo(1), new Foo(2), new Foo(5), 
                new Foo(6), new Foo(7), new Foo(8), new Foo(10), 
                new Foo(33), new Foo(4)
            }
        };

        public static TheoryData<int[]> Items = new TheoryData<int[]>
        {
            Array.Empty<int>(),
            new[] {1},
            new[] {1, 1},
            new[] {1, 2},
            new[] {2, 1, 1},
            new[] {1, 1, 2},
            new[] {1, 1, 2, 5, 6, 7},
            new[] {1, 1, 2, 5, 6, 7, 8, 10, 33, 4},
        };
    }
}