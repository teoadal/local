using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Local.Collections;
using Xunit;

namespace Local.Tests.Collections
{
    public class EnumerationShould
    {
        [Theory, MemberData(nameof(ItemsCount))]
        public void EnumerateAllElements(int itemsCount)
        {
            var items = Enumerable.Range(0, itemsCount).ToArray();
            var enumerated = new HashSet<int>(itemsCount);

            var vector = new LocalVector<int>(items);
            foreach (var element in vector)
            {
                enumerated.Add(element).Should().BeTrue();
            }

            enumerated.Count.Should().Be(items.Length);
        }

        [Theory, MemberData(nameof(ItemsCount))]
        public void EnumerateElementsInOrder(int itemsCount)
        {
            var items = Enumerable.Range(0, itemsCount).ToArray();
            var enumerated = new List<int>(itemsCount);

            var vector = new LocalVector<int>(items);
            foreach (var element in vector)
            {
                enumerated.Add(element);
            }

            enumerated.Should().ContainInOrder(items);
        }

        [Fact]
        public void NotEnumerateIfEmpty()
        {
            var vector = new LocalVector<int>();

            var executed = false;
            foreach (var _ in vector)
            {
                executed = true;
            }

            executed.Should().BeFalse();
        }

        public static TheoryData<int> ItemsCount = new TheoryData<int>
        {
            1, 2, 5, 10, 15, 20, 25, 50
        };
    }
}