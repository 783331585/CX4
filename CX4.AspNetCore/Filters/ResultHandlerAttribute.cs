using Newtonsoft.Json;

namespace Microsoft.AspNetCore.Mvc.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class ResultHandlerAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!(context.Result is NoContentResult) || !(context.Result is FileResult))
            {
                var result = context.Result as ObjectResult;
                context.Result = new ContentResult()
                {
                    Content = JsonConvert.SerializeObject(result.StatusCode == null ? ResultObject.Success(result.Value) : ResultObject.Fail(JsonConvert.SerializeObject(result.Value))),
                    ContentType = "application/json;charset=utf-8",
                };
            }
            base.OnResultExecuting(context);
        }
    }
}
