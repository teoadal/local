using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture.Xunit2;
using FluentAssertions;
using Local.Collections;
using Xunit;

namespace Local.Tests.Collections
{
    public class AddShould
    {
        [Theory, AutoData]
        public void AddItem(int item)
        {
            var vector = new LocalVector<int>();
            vector.Add(item);

            Assert.True(vector.Contains(item));
        }

        [Theory, MemberData(nameof(ItemsCount))]
        public void AddItems(int itemsCount)
        {
            var items = Enumerable.Range(0, Math.Abs(itemsCount)).ToArray();

            var vector = new LocalVector<int>();
            foreach (var item in items)
            {
                vector.Add(item);
                Assert.True(vector.Contains(item));
            }
        }

        [Theory, MemberData(nameof(ItemsCount))]
        public void AddRangeOfItems(int itemsCount)
        {
            var items = Enumerable.Range(0, Math.Abs(itemsCount)).ToArray();

            var vector = new LocalVector<int>();
            vector.AddRange(items);

            foreach (var item in items)
            {
                Assert.True(vector.Contains(item));
            }
        }

        [Theory, MemberData(nameof(ItemsCount))]
        public void AddRangeOfItemsCollection(int itemsCount)
        {
            var items = Enumerable.Range(0, Math.Abs(itemsCount)).ToArray();

            var vector = new LocalVector<int>();
            vector.AddRange(items);
            vector.AddRange((ICollection<int>) items);
            vector.AddRange((IEnumerable<int>) items);

            foreach (var item in items)
            {
                vector
                    .Count((i, arg) => i == arg, item)
                    .Should().Be(3);
            }
        }

        public static TheoryData<int> ItemsCount() => new TheoryData<int>
        {
            0, 1, 5, 10, 20, 100, 200
        };
    }
}