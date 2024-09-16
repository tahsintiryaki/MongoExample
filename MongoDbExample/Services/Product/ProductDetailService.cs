using MongoDbExample.Entities;
using MongoDbExample.Repositories;
using MongoDbExample.Repositories.Core;

namespace MongoDbExample.Services;

public class ProductDetailService: BaseService<ProductDetails>, IProductDetailService
{
    public ProductDetailService(IBaseRepository<ProductDetails> baseRepository) : base(baseRepository)
    {
    }
}