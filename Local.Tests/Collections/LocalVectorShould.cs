using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Local.Collections;
using Xunit;

namespace Local.Tests.Collections
{
    public class LocalVectorShould
    {
        [Fact]
        public void ClearLength()
        {
            var vector = new LocalVector<int>(Enumerable.Range(0, 10));
            vector.Clear();

            vector.Length.Should().Be(0);
        }

        [Fact]
        public void ContainsElement()
        {
            object item = new object();
            var vector = new LocalVector<object>(item);

            vector
                .Contains(item)
                .Should().BeTrue();
        }

        [Fact]
        public void ContainsElementWithComparer()
        {
            object item = new object();
            var vector = new LocalVector<object>(item);

            vector
                .Contains(item, EqualityComparer<object>.Default)
                .Should().BeTrue();
        }

        [Theory, MemberData(nameof(UnsortedItems))]
        public void GetElementByIndex(int[] items)
        {
            var vector = new LocalVector<int>(items);

            for (var i = 0; i < vector.Length; i++)
            {
                vector[i]
                    .Should().Be(items[i]);
            }
        }

        [Fact]
        public void NotContainsElement()
        {
            var vector = new LocalVector<object>();

            vector
                .Contains(new object())
                .Should().BeFalse();
        }

        [Theory, MemberData(nameof(UnsortedItems))]
        public void ReverseElements(int[] items)
        {
            var vector = new LocalVector<int>(items);
            
            vector.Reverse();

            vector.ToArray()
                .Should().ContainInOrder(items.Reverse());
        }
        
        [Theory, MemberData(nameof(UnsortedItems))]
        public void ReturnLast(int[] items)
        {
            if (items.Length == 0)
            {
                Assert.Throws<InvalidOperationException>(() => new LocalVector<int>().Last());
                return;
            }
            
            var vector = new LocalVector<int>(items);
            vector
                .Last()
                .Should().Be(items.Last());
        }

        [Theory, MemberData(nameof(UnsortedItems))]
        public void SortElements(int[] items)
        {
            var vector = new LocalVector<int>(items);
            vector.Sort();

            Array.Sort(items);

            vector.ToArray()
                .Should().ContainInOrder(items);
        }

        [Theory, MemberData(nameof(UnsortedItems))]
        public void SortElementsWithComparer(int[] items)
        {
            var comparer = Comparer<int>.Default;
            var vector = new LocalVector<int>(items);
            vector.Sort(comparer);

            Array.Sort(items, comparer);

            vector.ToArray()
                .Should().ContainInOrder(items);
        }

        [Theory, MemberData(nameof(UnsortedFoo))]
        public void SortElementsByProperty(Foo[] items)
        {
            var vector = new LocalVector<Foo>(items);
            vector.Sort(foo => foo.Value);

            var sorted = items
                .OrderBy(foo => foo.Value)
                .Cast<object>()
                .ToArray();

            vector.ToArray()
                .Should().ContainInOrder(sorted);
        }

        [Theory, MemberData(nameof(UnsortedFoo))]
        public void SortElementsByPropertyWithComparer(Foo[] items)
        {
            var comparer = Comparer<int>.Default;
            var vector = new LocalVector<Foo>(items);
            vector.Sort(foo => foo.Value, comparer);

            var sorted = items
                .OrderBy(foo => foo.Value, comparer)
                .Cast<object>()
                .ToArray();

            vector.ToArray()
                .Should().ContainInOrder(sorted);
        }

        [Fact]
        public void ThrowIfOutOfRange() => Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var vector = new LocalVector<int>();
            var _ = vector[int.MaxValue];
        });

        public static TheoryData<int[]> UnsortedItems = new TheoryData<int[]>
        {
            Array.Empty<int>(),
            new[] {1},
            new[] {6, 1},
            new[] {1, 2, 3},
            new[] {2, 5, 6, 1},
            new[] {2, 5, 6, 1, 0, -1},
            new[] {25, 15, 16, 1, 20, 10, 22}
        };

        public static TheoryData<Foo[]> UnsortedFoo = new TheoryData<Foo[]>
        {
            Array.Empty<Foo>(),
            new[] {new Foo(1)},
            new[] {new Foo(6), new Foo(1)},
            new[] {new Foo(1), new Foo(2), new Foo(3)},
            new[] {new Foo(2), new Foo(5), new Foo(6), new Foo(1)}
        };
    }
}