using Chloe.Infrastructure;
using Chloe.Oracle;

namespace CX4.Chloe.Oracle
{
    /// <summary>
    /// 读库
    /// </summary>
    internal class OracleReaderContext : OracleContext, IDbReaderContext
    {
        public OracleReaderContext(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }
    }
}
