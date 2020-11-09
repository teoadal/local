using System;
using System.Collections.Generic;
using FluentAssertions;
using Local.Collections;
using Xunit;

namespace Local.Tests.Collections
{
    public class ConstructorShould
    {
        [Theory, MemberData(nameof(Items))]
        public void Construct(object[] items)
        {
            var vector = items.Length switch
            {
                0 => new LocalVector<object>(),
                1 => new LocalVector<object>(items[0]),
                2 => new LocalVector<object>(items[0], items[1]),
                3 => new LocalVector<object>(items[0], items[1], items[2]),
                4 => new LocalVector<object>(items[0], items[1], items[2], items[3]),
                5 => new LocalVector<object>(items[0], items[1], items[2], items[3], items[4]),
                6 => new LocalVector<object>((IEnumerable<object>) items),
                7 => new LocalVector<object>((ICollection<object>) items),
                8 => new LocalVector<object>(items),
                _ => throw new InvalidOperationException()
            };

            Assert.Equal(vector.Length, items.Length);

            foreach (object element in items)
            {
                vector.Contains(element).Should().BeTrue();
            }
        }

        public static TheoryData<object[]> Items => new TheoryData<object[]>
        {
            Array.Empty<object>(),
            new object[] {0},
            new object[] {0, 1},
            new object[] {0, 1, 2},
            new object[] {0, 1, 2, 3},
            new object[] {0, 1, 2, 3, 4},
            new object[] {0, 1, 2, 3, 4, 5},
            new object[] {0, 1, 2, 3, 4, 5, 6},
            new object[] {0, 1, 2, 3, 4, 5, 6, 7},
        };
    }
}