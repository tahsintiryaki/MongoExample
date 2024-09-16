using MongoDbExample.Entities;
using MongoDbExample.Repositories.Core;

namespace MongoDbExample.Repositories;

public interface IProductDetailRepository:IBaseRepository<ProductDetails>
{
    void MyCustomMethod(string value);
}