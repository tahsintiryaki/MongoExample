using MongoDbExample.RedisCache.Interfaces;
using MongoDbExample.RedisCache.Services;
using StackExchange.Redis;

namespace MongoDbExample.Configurations;

public  static class RedisConfiguration
{
    public static IServiceCollection UseRedis(this IServiceCollection services, IConfiguration configuration)
    {
    
        var redisConnection = ConnectionMultiplexer.Connect(configuration["RedisCache:ConnectionString"]);
        services.AddSingleton<IConnectionMultiplexer>(redisConnection);
        
        services.AddSingleton<IRedisCacheService, RedisCacheService>();
        return services;
    }
}