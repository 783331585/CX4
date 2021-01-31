namespace CX4.Core.Exceptions
{
    /// <summary>
    /// 领域层异常
    /// </summary>
    public class DomainException : CX4Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
