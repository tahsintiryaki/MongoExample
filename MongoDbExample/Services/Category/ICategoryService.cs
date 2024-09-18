using MongoDbExample.Entities;

namespace MongoDbExample.Services;

public interface ICategoryService:IBaseService<Category>
{
    Task<IEnumerable<Category>> GetCategoriesFromCache(string cacheKey);
    Task CreateCategoryandSetRedis(Category category, string cacheKey);
}