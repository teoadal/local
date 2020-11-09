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
    public class CreateBenchmark
    {
        [Params(1, 3, 5, 7, 10)]
        public int Count;

        private Foo[] _items;

        [GlobalSetup]
        public void Init()
        {
            _items = Enumerable
                .Range(0, Count)
                .Select(i => new Foo(i))
                .ToArray();
        }

        [Benchmark(Baseline = true)]
        public int List()
        {
            var list = new List<Foo>(_items);
            return list.Count;
        }
        
        [Benchmark]
        public int LocalVector()
        {
            var list = new LocalVector<Foo>(_items);
            return list.Length;
        }
    }
}