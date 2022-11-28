using StackExchange.Redis;
using System;
using System.Threading.Tasks;


namespace ENIMS.Common
{
    public class RedisMemoryCacherV3: IRedisMemoryCacherV3
    {
        private static IDatabase _cache;
        public void SetConfig(IConnectionMultiplexer connectionMultiplexer)
        {
            _cache = connectionMultiplexer.GetDatabase();
        }
        public async Task<RedisResponse<T>> GetValue<T>(string itemKey)
        {
            RedisResponse<T> redisResponse = new RedisResponse<T>();
            try
            {
                
                T itemValue = await RedisCacheExtensions.GetAsync<T>(_cache, itemKey);

                if (itemValue == null)
                {
                    redisResponse.IsFound = false;
                }
                else
                {
                    redisResponse.Value = itemValue;
                    redisResponse.IsFound = true;
                }
            }
            catch (Exception ex) {
                return null;
            }
            
            return redisResponse;
        }
        public Task Add<T>(string itemKey, T itemValue, DateTimeOffset cacheExpiration)
        {
            try
            {
               return RedisCacheExtensions.SetAsync(_cache, itemKey, itemValue, cacheExpiration-DateTimeOffset.UtcNow);
            }
            catch (Exception ex) {
                
                return null;
            }
        }
    }
}
