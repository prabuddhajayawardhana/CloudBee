namespace Catalog.Domain.Configurations;

public sealed record MongoDbSettings : IMongoDbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}
