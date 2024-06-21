using Benchmark.Api.Controllers;
using BenchmarkDotNet.Running;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();
if (args.Contains("--benchmark"))
{
    BenchmarkRunner.Run<CatalogApiBenchmark>();
}
else
{
    // Configure the HTTP request pipeline.

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}