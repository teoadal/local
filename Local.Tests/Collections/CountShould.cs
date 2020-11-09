using System.Linq;
using FluentAssertions;
using Local.Collections;
using Xunit;

namespace Local.Tests.Collections
{
    public class CountShould : LinqTests
    {
        [Theory, MemberData(nameof(Items))]
        public void CheckItems(int[] items)
        {
            static bool Predicate(int i) => i == 1;

            var vector = new LocalVector<int>(items);
            vector
                .Count(Predicate)
                .Should().Be(items.Count(Predicate));
        }

        [Theory, MemberData(nameof(Items))]
        public void CheckItemsWithArg(int[] items)
        {
            const int argument = 2;

            var vector = new LocalVector<int>(items);
            vector
                .Count((i, arg) => i == arg, argument)
                .Should().Be(items.Count(i => i == argument));
        }
    }
}