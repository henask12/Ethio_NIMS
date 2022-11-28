using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENIMS.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace ENIMS.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CachedAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveSeconds;

        public CachedAttribute(int timeToLiveSeconds)
        {
            _timeToLiveSeconds = timeToLiveSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                var cacheSettings = context.HttpContext.RequestServices.GetRequiredService<RedisCacheSettings>();

                if (!cacheSettings.Enabled)
                {
                    await next();
                    return;
                }
               
                var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();
                var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);

                cacheKey = cacheKey.ToLower() /*+ "CN="+ CurrentAppSettings.CurrentCompanyName.ToLower()*/;
                //change the key to lower case

                var cachedResponse = await cacheService.GetCachedResponseAsync(cacheKey);

                if (!string.IsNullOrEmpty(cachedResponse))
                {
                    var contentResult = new ContentResult
                    {
                        Content = cachedResponse,
                        ContentType = "application/json",
                        StatusCode = 200
                    };
                    context.Result = contentResult;
                    return;
                }
                
                //before controller
                var executedContext = await next();
                //after controller

                if (executedContext.Result is OkObjectResult okObjectResult)
                {
                    await cacheService.CacheResponseAsync(cacheKey, okObjectResult.Value, TimeSpan.FromSeconds(_timeToLiveSeconds));
                }
            }
            catch (Exception ex)
            {

                await next();
                return;
            }
        }

        private static string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();

            keyBuilder.Append($"{request.Path}");

            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }
            return keyBuilder.ToString();
        }
    }
}
