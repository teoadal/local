using System;
using System.Linq;
using AutoFixture.Xunit2;
using FluentAssertions;
using Local.Collections;
using Xunit;

namespace Local.Tests.Collections
{
    public class ExtensionsShould
    {
        [Theory, AutoData]
        public void CalculateMinDouble(double[] items)
        {
            var vector = new LocalVector<double>(items);
            vector
                .Min()
                .Should().Be(items.Min());

            vector.Reverse();

            vector
                .Min()
                .Should().Be(items.Reverse().Min());
        }

        [Theory, AutoData]
        public void CalculateMinFloat(float[] items)
        {
            var vector = new LocalVector<float>(items);
            vector
                .Min()
                .Should().Be(items.Min());

            vector.Reverse();

            vector
                .Min()
                .Should().Be(items.Reverse().Min());
        }

        [Theory, AutoData]
        public void CalculateMinInt(int[] items)
        {
            var vector = new LocalVector<int>(items);
            vector
                .Min()
                .Should().Be(items.Min());

            vector.Reverse();

            vector
                .Min()
                .Should().Be(items.Reverse().Min());
        }

        [Theory, AutoData]
        public void CalculateMaxDouble(double[] items)
        {
            var vector = new LocalVector<double>(items);
            vector
                .Max()
                .Should().Be(items.Max());

            vector.Reverse();

            vector
                .Max()
                .Should().Be(items.Reverse().Max());
        }

        [Theory, AutoData]
        public void CalculateMaxFloat(float[] items)
        {
            var vector = new LocalVector<float>(items);
            vector
                .Max()
                .Should().Be(items.Max());

            vector.Reverse();

            vector
                .Max()
                .Should().Be(items.Reverse().Max());
        }

        [Theory, AutoData]
        public void CalculateMaxInt(int[] items)
        {
            var vector = new LocalVector<int>(items);
            vector
                .Max()
                .Should().Be(items.Max());

            vector.Reverse();

            vector
                .Max()
                .Should().Be(items.Reverse().Max());
        }

        [Fact]
        public void ThrowIfCalculateMaxByEmptyVector() => Assert.Throws<InvalidOperationException>(() =>
        {
            var vector = new LocalVector<double>();
            vector.Max();
        });
        
        [Fact]
        public void ThrowIfCalculateMinByEmptyVector() => Assert.Throws<InvalidOperationException>(() =>
        {
            var vector = new LocalVector<double>();
            vector.Min();
        });
    }
}