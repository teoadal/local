using System.Linq;
using FluentAssertions;
using Local.Collections;
using Xunit;

namespace Local.Tests.Collections
{
    public class WhereShould : LinqTests
    {
        [Theory, MemberData(nameof(Items))]
        public void FilterElements(int[] items)
        {
            static bool Predicate(int i) => i == 1;

            var vector = new LocalVector<int>(items);

            vector
                .Where(Predicate).ToArray()
                .Should().ContainInOrder(items.Where(Predicate));
        }

        [Theory, MemberData(nameof(Items))]
        public void FilterElementsWithArg(int[] items)
        {
            const int argument = 1;

            var vector = new LocalVector<int>(items);

            vector
                .Where((i, arg) => i == arg, argument).ToArray()
                .Should().ContainInOrder(items.Where(i => i == argument));
        }
    }
}