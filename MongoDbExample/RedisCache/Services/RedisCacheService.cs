using MongoDbExample.RedisCache.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MongoDbExample.RedisCache.Services;

public class RedisCacheService : IRedisCacheService
{
    private readonly IConnectionMultiplexer _redisConnection;
    private readonly IDatabase _cache;

    public RedisCacheService(IConnectionMultiplexer redisConnection)
    {
        _redisConnection = redisConnection;
        _cache = _redisConnection.GetDatabase();
    }


    public async Task<T> GetValueAsync<T>(string key) where T : class
    {
        var cachedResponse = await _cache.StringGetAsync(key);
        if (string.IsNullOrEmpty(cachedResponse))
            return null;

        var deserializeObject = JsonConvert.DeserializeObject<T>(cachedResponse);
        return deserializeObject;
    }

    public async Task<bool> SetValueAsync(string key, object value)
    {
        var serializedResponse = JsonConvert.SerializeObject(value);
        return await _cache.StringSetAsync(key, serializedResponse, TimeSpan.FromHours(1));
    }

    public async Task Clear(string key)
    {
        await _cache.KeyDeleteAsync(key);
    }

    public void ClearAll()
    {
        var redisEndpoints = _redisConnection.GetEndPoints(true);
        foreach (var redisEndpoint in redisEndpoints)
        {
            var redisServer = _redisConnection.GetServer(redisEndpoint);
            redisServer.FlushAllDatabases();
        }
    }
}