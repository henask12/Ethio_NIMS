using ENIMS.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENIMS.Api
{

    [AttributeUsage(AttributeTargets.Method)]
    public class ClearCacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _key;

        public ClearCacheAttribute(string key)
        {
            _key = key;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
               
                //do noting
               
                //before controller
                var executedContext = await next();

                //after controller

                var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();
                

                //clear cache
                if (executedContext.Result is OkObjectResult okObjectResult)
                {
                    char[] delimiterChars = { ',' };
                    string[] keys = _key.Split(delimiterChars);
                    foreach (var key in keys) 
                    {
                        await cacheService.CacheRemoveAsync(key.ToLower() /*+ "CN=" + CurrentAppSettings.CurrentCompanyName.ToLower()*/);
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
