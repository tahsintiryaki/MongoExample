namespace MongoDbExample.RedisCache.Interfaces;

public interface IRedisCacheService
{
    Task<T> GetValueAsync<T>(string key) where T : class;
    Task<bool> SetValueAsync(string key, object value);
    Task Clear(string key);
    void ClearAll();
}