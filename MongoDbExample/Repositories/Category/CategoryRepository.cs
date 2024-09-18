using MongoDbExample.Entities;
using MongoDbExample.MongoContexts;
using MongoDbExample.RedisCache.Interfaces;
using MongoDbExample.Repositories.Core;

namespace MongoDbExample.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    private readonly IRedisCacheService _redisCache;

    public CategoryRepository(IMongoDBContext mongoContext, IRedisCacheService redisCache) : base(mongoContext)
    {
        _redisCache = redisCache;
    }


    public async Task<IEnumerable<Category>> GetCategoriesFromCache(string cacheKey)
    {
        var categories = await _redisCache.GetValueAsync<IEnumerable<Category>>(cacheKey);
        if (categories != null)
        {
            return categories;
        }
        else
        {
            var getCategories = Get(); 
            _redisCache.SetValueAsync(cacheKey, getCategories);
            return getCategories;
        }
    }

    public async Task SetCategoryCache(string cacheKey, object value)
    {
        
        await _redisCache.SetValueAsync(cacheKey, value);
    }
}