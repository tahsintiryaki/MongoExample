using MongoDbExample.Entities;
using MongoDbExample.Repositories.Core;

namespace MongoDbExample.Repositories;

public interface ICategoryRepository:IBaseRepository<Category>
{
     Task<IEnumerable<Category>> GetCategoriesFromCache(string cacheKey);
     Task SetCategoryCache(string cacheKey, object value);
}