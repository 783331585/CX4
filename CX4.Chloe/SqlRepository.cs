using System.Collections.Generic;
using System.Threading.Tasks;
using CX4.Domain.Repository;

namespace CX4.Chloe
{
    /// <inheritdoc cref="ISqlRepository"/>
    public class SqlRepository : ISqlRepository
    {
        private readonly IDbReaderContext _content;

        public SqlRepository(IDbReaderContext context)
        {
            _content = context;
        }

        public List<T> SqlQuery<T>(string sql) where T : class, new()
        {
            return SqlQuery<T>(sql, null);
        }

        public List<T> SqlQuery<T>(string sql, object parameter) where T : class, new()
        {
            return _content.SqlQuery<T>(sql, System.Data.CommandType.Text, parameter);
        }

        public Task<List<T>> SqlQueryAsync<T>(string sql) where T : class, new()
        {
            return SqlQueryAsync<T>(sql, null);
        }

        public Task<List<T>> SqlQueryAsync<T>(string sql, object parameter) where T : class, new()
        {
            return _content.SqlQueryAsync<T>(sql, System.Data.CommandType.Text, parameter);
        }
    }
}
