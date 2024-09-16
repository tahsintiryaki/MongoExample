using MongoDbExample.Entities;
using MongoDbExample.MongoContexts;
using MongoDbExample.Repositories.Core;

namespace MongoDbExample.Repositories;

public class ProductDetailRepository:BaseRepository<ProductDetails>,IProductDetailRepository
{
    public ProductDetailRepository(IMongoDBContext mongoContext) : base(mongoContext)
    {
    }

    public void MyCustomMethod(string value)
    {
        throw new NotImplementedException();
    }

   
}
