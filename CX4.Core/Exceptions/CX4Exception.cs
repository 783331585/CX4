using System;

namespace CX4.Core.Exceptions
{
    /// <summary>
    /// 框架异常基类
    /// </summary>
    public class CX4Exception : Exception
    {
        public CX4Exception(string message) : base(message) { }
    }
}
