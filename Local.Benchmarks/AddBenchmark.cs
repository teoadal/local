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
    public class AddBenchmark
    {
        [Params(3, 7, 10, 15, 20)] 
        public int Count;

        private object[] _items;

        [GlobalSetup]
        public void Init()
        {
            _items = Enumerable
                .Range(0, Count)
                .Select(_ => new object())
                .ToArray();
        }

        [Benchmark(Baseline = true)]
        public int List()
        {
            var list = new List<object>();
            foreach (var item in _items)
            {
                list.Add(item);
            }

            return list.Capacity;
        }

        [Benchmark]
        public int LocalVector()
        {
            var vector = new LocalVector<object>();
            foreach (var item in _items)
            {
                vector.Add(item);
            }

            return vector.Length;
        }
    }
}