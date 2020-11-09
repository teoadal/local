using System.Linq;
using FluentAssertions;
using Local.Collections;
using Xunit;

namespace Local.Tests.Collections
{
    public class AllShould : LinqTests
    {
        [Theory, MemberData(nameof(Items))]
        public void CheckItems(int[] items)
        {
            static bool Predicate(int i) => i == 1;

            var vector = new LocalVector<int>(items);
            vector
                .All(Predicate)
                .Should().Be(items.All(Predicate));
        }

        [Theory, MemberData(nameof(Items))]
        public void CheckItemsWithArg(int[] items)
        {
            const int argument = 2;

            var vector = new LocalVector<int>(items);
            vector
                .All((i, arg) => i == arg, argument)
                .Should().Be(items.All(i => i == argument));
        }
    }
}