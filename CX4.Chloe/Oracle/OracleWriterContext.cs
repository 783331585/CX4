using Chloe.Infrastructure;
using Chloe.Oracle;

namespace CX4.Chloe.Oracle
{
    /// <summary>
    /// 写库
    /// </summary>
    internal class OracleWriterContext : OracleContext, IDbWriterContext
    {
        public OracleWriterContext(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }
    }
}
