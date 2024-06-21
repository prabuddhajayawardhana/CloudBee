using BenchmarkDotNet.Attributes;

namespace Benchmark.Api.Controllers;
[MemoryDiagnoser]
public class CatalogApiBenchmark
{
    private static readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5000/") };

    [Benchmark]
    public async Task GetProductEndpoint()
    {
        var response = await _httpClient.GetAsync("/Catalog/GetProduct");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
    }

    [Benchmark]
    public async Task GetProductString()
    {
        var response = await _httpClient.GetAsync("/Catalog/GetProductString");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
    }
}
