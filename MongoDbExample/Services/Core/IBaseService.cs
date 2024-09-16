namespace MongoDbExample.Services;

public interface IBaseService<TEntity> where TEntity:class
{
    Task Create(TEntity obj);
    void Update(TEntity obj, string id);
    void Delete(string id);
    TEntity Get(string id);
    IEnumerable<TEntity>Get();
}