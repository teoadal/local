using System;
using System.Linq;
using FluentAssertions;
using Local.Collections;
using Xunit;

namespace Local.Tests.Collections
{
    public class FirstShould : LinqTests
    {
        [Theory, MemberData(nameof(Items))]
        public void FindFirstByPredicate(int[] items)
        {
            static bool Predicate(int i) => i == 1;

            if (items.Length == 0)
            {
                Assert.Throws<InvalidOperationException>(() => new LocalVector<int>().First(Predicate));
                return;
            }

            var vector = new LocalVector<int>(items);

            vector
                .First(Predicate)
                .Should().Be(items.First(Predicate));
        }

        [Theory, MemberData(nameof(Items))]
        public void FindFirstByPredicateWithArg(int[] items)
        {
            const int argument = 1;

            if (items.Length == 0)
            {
                Assert
                    .Throws<InvalidOperationException>(() => new LocalVector<int>()
                        .First((i, arg) => i == arg, argument));
                return;
            }

            var vector = new LocalVector<int>(items);

            vector
                .First((i, arg) => i == arg, argument)
                .Should().Be(items.First(i => i == argument));
        }

        [Theory, MemberData(nameof(Items))]
        public void ReturnFirstElement(int[] items)
        {
            if (items.Length == 0)
            {
                Assert.Throws<InvalidOperationException>(() => new LocalVector<int>().First());
                return;
            }

            var vector = new LocalVector<int>(items);

            vector
                .First()
                .Should().Be(items.First());
        }

        [Fact]
        public void ThrowIfNotFoundByPredicate()
        {
            Assert
                .Throws<InvalidOperationException>(() => new LocalVector<int>()
                    .First(i => i == 1));
        }

        [Fact]
        public void ThrowIfNotFoundByPredicateWithArg()
        {
            const int argument = 1;

            Assert
                .Throws<InvalidOperationException>(() => new LocalVector<int>()
                    .First((i, arg) => i == arg, argument));
        }
    }
}