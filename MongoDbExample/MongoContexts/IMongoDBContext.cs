using MongoDB.Driver;
using MongoDbExample.Entities;

namespace MongoDbExample.MongoContexts;

public interface IMongoDBContext
{
    IMongoCollection<ProductDetails> GetCollection<ProductDetails>(string name);
    
}