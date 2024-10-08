using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbExample.Configurations;
using MongoDbExample.Entities;

namespace MongoDbExample.MongoContexts;

public class MongoDbContext:IMongoDBContext
{
 
    private IMongoDatabase _db { get; set; }
    private MongoClient _mongoClient { get; set; }
    public IClientSessionHandle Session { get; set; }
    
    public MongoDbContext(IOptions<MongoDbSettings> configuration)
    {
        _mongoClient = new MongoClient(configuration.Value.ConnectionString);
        _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
    }
    
    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _db.GetCollection<T>(name);
        
    }
}