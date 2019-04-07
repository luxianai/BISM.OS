using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BISM.OS.AOP
{
    /// <summary>
    /// 面向切面的 日志 使用
    /// </summary>
    public class LogAOP : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //记录被拦截方法信息的日志信息
            var dataIntercept = $"{DateTime.Now:yyyyMMdd HH:mm:ss} " +
                $"当前执行方法：{ invocation.Method.Name} " +
                $"参数是： {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())} \r\n";

            try
            {
                // MiniProfiler.Current.Step($"执行Service方法：{invocation.Method.Name}() -> ");
                //在被拦截的方法执行完毕后 继续执行当前方法，注意是被拦截的是异步的
                invocation.Proceed();
            }
            catch (Exception e)
            {
                //执行的 service 中，收录异常
                // MiniProfiler.Current.CustomTiming("Errors：", e.Message);
                //执行的 service 中，捕获异常
                dataIntercept += ($"方法执行中出现异常：{e.Message + e.InnerException}");
            }

            dataIntercept += ($"方法执行完毕，返回结果：{invocation.ReturnValue}");
        }
    }
}
