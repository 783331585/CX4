using System.Data;
using System.Linq;
using System.Reflection;
using Chloe.Entity;
using Chloe.Infrastructure;
using Oracle.ManagedDataAccess.Client;

namespace CX4.Chloe.Oracle
{
    internal class OracleConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connString;
        static OracleConnectionFactory()
        {
            EntityMapping();
        }

        public OracleConnectionFactory(string connString)
        {
            _connString = connString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreateConnection()
        {
            OracleConnection oracleConnection = new OracleConnection(_connString);
            IDbConnection conn = new OracleConnectionDecorator(oracleConnection);
            return conn;
        }

        /// <summary>
        /// 领域层实体映射
        /// </summary>
        private static void EntityMapping()
        {
            var mapTypeList = Assembly.GetExecutingAssembly().GetTypes().Where(k => !k.IsGenericType && typeof(IEntityTypeBuilder).IsAssignableFrom(k)).ToList();
            foreach (var item in mapTypeList)
            {
                DbConfiguration.UseTypeBuilders(item);
            }
        }
    }
}
