using System.Linq;
using FluentAssertions;
using Local.Collections;
using Xunit;

namespace Local.Tests.Collections
{
    public class SelectShould : LinqTests
    {
        [Theory, MemberData(nameof(Items))]
        public void ReturnElements(int[] items)
        {
            static bool Predicate(int i) => i == 1;

            var vector = new LocalVector<int>(items);

            vector
                .Select(Predicate).ToArray()
                .Should().ContainInOrder(items.Select(Predicate));
        }

        [Theory, MemberData(nameof(Items))]
        public void FilterElementsWithArg(int[] items)
        {
            const int argument = 1;

            var vector = new LocalVector<int>(items);

            vector
                .Select((i, arg) => i == arg, argument).ToArray()
                .Should().ContainInOrder(items.Select(i => i == argument));
        }
    }
}