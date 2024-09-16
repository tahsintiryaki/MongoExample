using MongoDbExample.Entities;
using MongoDbExample.MongoContexts;
using MongoDbExample.Repositories.Core;

namespace MongoDbExample.Repositories;

public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
{
    public CategoryRepository(IMongoDBContext mongoContext) : base(mongoContext)
    {
    }
}