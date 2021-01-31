using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Mvc.Filters
{
    /// <summary>
    /// 异常处理
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionHandlerAttribute> _log;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public ExceptionHandlerAttribute(ILogger<ExceptionHandlerAttribute> log)
        {
            _log = log;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            string msg = exception.Message;
            _log.LogError(exception, msg);
            context.Result = new JsonResult(ResultObject.Fail(msg))
            {
                ContentType = "application/json;charset=utf-8"
            };
            context.ExceptionHandled = true;
            return base.OnExceptionAsync(context);
        }
    }
}
