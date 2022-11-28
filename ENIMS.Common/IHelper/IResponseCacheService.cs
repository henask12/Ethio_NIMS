using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.Common
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeTimeLive);
        Task<string> GetCachedResponseAsync(string cacheKey);
        Task CacheRemoveAsync(string cacheKey);
    }
}
