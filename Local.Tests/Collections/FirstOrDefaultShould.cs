using System;
using System.Linq;
using FluentAssertions;
using Local.Collections;
using Xunit;

namespace Local.Tests.Collections
{
    public class FirstOrDefaultShould : LinqTests
    {
        [Theory, MemberData(nameof(Items))]
        public void FindFirstByPredicate(int[] items)
        {
            static bool Predicate(int i) => i == 1;

            var vector = new LocalVector<int>(items);

            vector
                .FirstOrDefault(Predicate)
                .Should().Be(items.FirstOrDefault(Predicate));
        }

        [Theory, MemberData(nameof(Items))]
        public void FindFirstByPredicateWithArg(int[] items)
        {
            const int argument = 1;

            var vector = new LocalVector<int>(items);

            vector
                .FirstOrDefault((i, arg) => i == arg, argument)
                .Should().Be(items.FirstOrDefault(i => i == argument));
        }

        [Fact]
        public void NotThrowIfNotFoundByPredicate()
        {
            new LocalVector<int>()
                .FirstOrDefault(i => i == 1)
                .Should().Be(0);
        }

        [Fact]
        public void NotThrowIfNotFoundByPredicateWithArg()
        {
            const int argument = 1;

            new LocalVector<int>()
                .FirstOrDefault((i, arg) => i == arg, argument)
                .Should().Be(0);
        }

        [Theory, MemberData(nameof(Items))]
        public void ReturnFirstOrDefaultElement(int[] items)
        {
            var vector = new LocalVector<int>(items);

            vector
                .FirstOrDefault()
                .Should().Be(items.FirstOrDefault());
        }
    }
}