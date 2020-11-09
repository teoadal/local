using System.Linq;
using FluentAssertions;
using Local.Collections;
using Xunit;

namespace Local.Tests.Collections
{
    public class OrderByShould : LinqTests
    {
        [Theory, MemberData(nameof(FooItems))]
        public void SortElements(Foo[] items)
        {
            static int KeySelector(Foo foo) => foo.Value;
            
            var vector = new LocalVector<Foo>(items);
            vector
                .OrderBy(KeySelector).ToArray()
                .Should().ContainInOrder(items.OrderBy(KeySelector));
        }
    }
}