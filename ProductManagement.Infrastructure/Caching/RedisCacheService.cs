using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using StackExchange.Redis;
using System.Data.Common;

namespace ProductManagement.Infrastructure.Caching
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDatabase _db;

        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }
        public async Task SetAsync(string key, string value, TimeSpan expiration)
        {
            await _db.StringSetAsync(key, value, expiration);
        }
        public async Task<string?> GetAsync(string key)
        {
            return await _db.StringGetAsync(key);
        }
        public async Task RemoveAsync(string key)
        {
            await _db.KeyDeleteAsync(key);
        }
    }
}
