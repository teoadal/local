using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Local.Collections;

namespace Local.Benchmarks
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [MarkdownExporterAttribute.GitHub]
    [MeanColumn, MemoryDiagnoser]
    public class LinqBenchmark
    {
        [Params(3, 7, 10, 15, 20)]
        public int Count;

        private int _argument;
        private Foo[] _items;

        [GlobalSetup]
        public void Init()
        {
            _argument = Count / 2;
            _items = Enumerable
                .Range(0, Count)
                .Reverse()
                .Select(i => new Foo(i))
                .ToArray();
        }

        [Benchmark(Baseline = true)]
        public int List()
        {
            return new List<Foo>(_items)
                .OrderBy(foo => foo.Value)
                .Where(foo => foo.Value > _argument)
                .Select(foo => foo.Value)
                .Max();
        }
        
        [Benchmark]
        public int LocalVector()
        {
            return new LocalVector<Foo>(_items)
                .OrderBy(foo => foo.Value)
                .Where((foo, arg) => foo.Value > 0, _argument)
                .Select(foo => foo.Value)
                .Max();
        }
    }
}