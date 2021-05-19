using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace P39.Course.dotnetCoreLib.Filters
{
    public class CustomResourceFilterAttribute: Attribute, IResourceFilter
    {
        private static readonly Dictionary<string, object> _cache = new Dictionary<string, object>();
        private string _cacheKey;

        /// <summary>
        /// before controller initialization, check cache.
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _cacheKey = context.HttpContext.Request.Path.ToString();
            if (_cache.ContainsKey(_cacheKey))
            {
                var cachedValue = _cache[_cacheKey] as ViewResult;
                if (cachedValue != null)
                {
                    context.Result = cachedValue;//block the following steps
                }
            }
        }

        /// <summary>
        /// after request handled, cache if not have. 
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //if the key is not cached.
            if (!string.IsNullOrEmpty(_cacheKey) && !_cache.ContainsKey(_cacheKey))
            {
                var result = context.Result as ViewResult;
                if (result != null)
                {
                    _cache.Add(_cacheKey, result);
                }

            }

        }


    }
}
