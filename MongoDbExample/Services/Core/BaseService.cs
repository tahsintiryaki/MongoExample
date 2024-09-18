using MongoDbExample.Repositories.Core;

namespace MongoDbExample.Services;

public class BaseService<TEntity>:IBaseService<TEntity> where TEntity : class
{
    private readonly IBaseRepository<TEntity> _baseRepository;

    public BaseService(IBaseRepository<TEntity> baseRepository)
    {
        _baseRepository = baseRepository;
    }


    public async Task Create(TEntity obj)
    {
        await _baseRepository.Create(obj);
        
    }

    public void Update(TEntity obj, string id )
    {
       _baseRepository.Update(obj,id);
    }

    public void Delete(string id)
    {
        _baseRepository.Delete(id);
    }

    public TEntity Get(string id)
    {
        return _baseRepository.Get(id);
    }

    public IEnumerable<TEntity> Get()
    {
        return _baseRepository.Get();
    }
}