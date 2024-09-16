using MongoDbExample.Entities;
using MongoDbExample.Repositories;
using MongoDbExample.Repositories.Core;

namespace MongoDbExample.Services;

public class CategoryService:BaseService<Category>,ICategoryService
{
    public CategoryService(IBaseRepository<Category> baseRepository) : base(baseRepository)
    {
    }
}