using System.Linq;
using FluentAssertions;
using Local.Collections;
using Xunit;

namespace Local.Tests.Collections
{
    public class AnyShould : LinqTests
    {
        [Theory, MemberData(nameof(Items))]
        public void CheckItems(int[] items)
        {
            static bool Predicate(int i) => i == 1;

            var vector = new LocalVector<int>(items);
            vector
                .Any(Predicate)
                .Should().Be(items.Any(Predicate));
        }

        [Theory, MemberData(nameof(Items))]
        public void CheckItemsWithArg(int[] items)
        {
            const int argument = 2;

            var vector = new LocalVector<int>(items);
            vector
                .Any((i, arg) => i == arg, argument)
                .Should().Be(items.Any(i => i == argument));
        }

        [Theory, MemberData(nameof(Items))]
        public void CheckItemsByLength(int[] items)
        {
            var vector = new LocalVector<int>(items);
            vector
                .Any()
                .Should().Be(items.Any());
        }
    }
}