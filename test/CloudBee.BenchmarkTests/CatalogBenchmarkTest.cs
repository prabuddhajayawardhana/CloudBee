using Benchmark.Api.Controllers;
using BenchmarkDotNet.Running;

namespace CloudBee.BenchmarkTests
{
    public class CatalogBenchmarkTest
    {
        [Fact]
        public void RunBenchmarks()
        {
            var summary = BenchmarkRunner.Run<CatalogApiBenchmark>();
            // Optionally assert on benchmark results here
        }
    }
}