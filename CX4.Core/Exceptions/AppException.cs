namespace CX4.Core.Exceptions
{
    /// <summary>
    /// 应用层异常
    /// </summary>
    public class AppException : CX4Exception
    {
        public AppException(string message) : base(message) { }
    }
}
