using MongoDbExample.Entities;
using MongoDbExample.Repositories.Core;

namespace MongoDbExample.Repositories;

public interface ICategoryRepository:IBaseRepository<Category>
{
    
}