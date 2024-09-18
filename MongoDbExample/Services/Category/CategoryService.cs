using MongoDbExample.Entities;
using MongoDbExample.RedisCache.Interfaces;
using MongoDbExample.Repositories;
using MongoDbExample.Repositories.Core;

namespace MongoDbExample.Services;

public class CategoryService:BaseService<Category>,ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IRedisCacheService _redisCache;
    public CategoryService(IBaseRepository<Category> baseRepository, ICategoryRepository categoryRepository, IRedisCacheService redisCache) : base(baseRepository)
    {
        _categoryRepository = categoryRepository;
        _redisCache = redisCache;
    }

    public async Task<IEnumerable<Category>> GetCategoriesFromCache(string cacheKey)
    {
        return await _categoryRepository.GetCategoriesFromCache(cacheKey);
    }


    public async Task CreateCategoryandSetRedis(Category category, string cacheKey)
    {
       await Create(category);
       var getCategories =  Get();
       await _redisCache.SetValueAsync(cacheKey, getCategories);
        
    }
}