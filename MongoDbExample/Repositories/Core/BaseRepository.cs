using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbExample.MongoContexts;
using MongoDbExample.RedisCache.Interfaces;

namespace MongoDbExample.Repositories.Core;

public class BaseRepository<TEntity>:IBaseRepository<TEntity> where TEntity:class
{
    protected readonly IMongoDBContext _mongoContext;
    protected IMongoCollection<TEntity> _dbCollection;
    

    public BaseRepository(IMongoDBContext mongoContext)
    {
        _mongoContext = mongoContext;
        _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);;
    }
    public async Task Create(TEntity obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
        }
        await _dbCollection.InsertOneAsync(obj);
        
    }

    public void Delete(string id)
    {
        var objectId = new ObjectId(id);
        _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId));
    }

    public TEntity Get(string id)
    {

        var objectId = new ObjectId(id);

        FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);

        return  _dbCollection.FindAsync(filter).Result.FirstOrDefault();
    }

    public IEnumerable<TEntity> Get()
    {
        var all =  _dbCollection.Find(Builders<TEntity>.Filter.Empty);
        return  all.ToList();
    }

    public virtual void  Update(TEntity obj, string id)
    {
       
            var objectId = new ObjectId(id);
            var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
         _dbCollection.ReplaceOneAsync(filter, obj);
        
      
    }
}
  
