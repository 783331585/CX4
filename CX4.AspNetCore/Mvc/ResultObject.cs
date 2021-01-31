namespace Microsoft.AspNetCore.Mvc
{
    public class ResultObject
    {

        /// <summary>
        /// 
        /// </summary>
        public int retStatus { get; set; } = 200;

        /// <summary>
        /// 
        /// </summary>
        public dynamic retBody { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public string retMsg { get; set; } = "";

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data"></param>
        public static ResultObject Success(dynamic data)
        {
            return new ResultObject { retBody = data };
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="retStatus"></param>
        /// <returns></returns>
        public static ResultObject Fail(string msg, int retStatus = 500)
        {
            return new ResultObject { retStatus = retStatus, retMsg = msg };
        }
    }
}
