using BISM.OS.Cache;
using BISM.OS.Common;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BISM.OS.AOP
{
    /// <summary>
    /// 面向切面的缓存使用
    /// </summary>
    public class CacheAOP : IInterceptor
    {
        //通过注入的方式，把缓存操作接口通过构造函数注入
        private readonly ICacheService _cache;
        public CacheAOP(ICacheService cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// Intercept方法是拦截的关键所在，
        /// 也是IInterceptor接口中的唯一定义
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            //对当前方法的特性验证
            //如果需要验证
            if (method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(CacheAttribute)) is CacheAttribute qCachingAttribute)
            {
                //获取自定义缓存键
                var cacheKey = CustomCacheKey(invocation);
                //根据key获取相应的缓存值
                var cacheValue = _cache.Get(cacheKey);
                if (cacheValue != null)
                {
                    //将当前获取到的缓存值，赋值给当前执行方法
                    invocation.ReturnValue = cacheValue;
                    return;
                }
                //去执行当前的方法
                invocation.Proceed();
                //存入缓存
                if (!string.IsNullOrWhiteSpace(cacheKey))
                {
                    _cache.Set(cacheKey, invocation.ReturnValue);
                }
            }
            else
            {
                invocation.Proceed();//直接执行被拦截方法
            }
        }

        /// <summary>
        /// 自定义缓存键
        /// </summary>
        /// <param name="invocation"></param>
        /// <returns></returns>
        private string CustomCacheKey(IInvocation invocation)
        {
            var typeName = invocation.TargetType.Name;
            var methodName = invocation.Method.Name;
            var methodArguments = invocation.Arguments.Select(GetArgumentValue).Take(3).ToList();//获取参数列表，最多三个

            string key = $"{typeName}:{methodName}:";
            foreach (var param in methodArguments)
            {
                key += $"{param}:";
            }

            return key.TrimEnd(':');
        }

        /// <summary>
        /// object 转 string
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private string GetArgumentValue(object arg)
        {
            if (arg is int || arg is long || arg is string)
            {
                return arg.ToString();
            }
            else if (arg is DateTime)
            {
                return ((DateTime)arg).ToString("yyyyMMddHHmmss");
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
