using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.Common
{
    public interface IRedisMemoryCacherV3
    {
        Task<RedisResponse<T>> GetValue<T>(string itemKey);
        Task Add<T>(string itemKey, T itemValue, DateTimeOffset cacheExpiration);
        void SetConfig(IConnectionMultiplexer connectionMultiplexer);
    }
}
