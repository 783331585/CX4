using System.Collections.Generic;
using System.Threading.Tasks;

namespace CX4.Domain.Repository
{
    /// <summary>
    /// sql语句
    /// </summary>
    public interface ISqlRepository
    {
        /// <summary>
        /// sql语句查询
        /// </summary>
        /// <typeparam name="T">返回的数据类型</typeparam>
        /// <param name="sql">sql语句，如：select * from Users where Id=:Id</param>
        /// <returns></returns>
        List<T> SqlQuery<T>(string sql) where T : class, new();

        /// <summary>
        /// 基于sql语句
        /// </summary>
        /// <typeparam name="T">返回的数据类型</typeparam>
        /// <param name="sql">sql语句，如：select * from Users where Id=:Id</param>
        /// <param name="parameter">参数，如：new { Id = 1 }</param>
        /// <returns></returns>
        List<T> SqlQuery<T>(string sql, object parameter) where T : class, new();

        ///// <summary>
        ///// sql语句查询
        ///// </summary>
        ///// <typeparam name="T">返回的数据类型</typeparam>
        ///// <param name="sql">sql语句，如：select * from Users where Id=:Id</param>
        ///// <returns></returns>
        Task<List<T>> SqlQueryAsync<T>(string sql) where T : class, new();

        ///// <summary>
        ///// sql语句查询
        ///// </summary>
        ///// <typeparam name="T">返回的数据类型</typeparam>
        ///// <param name="sql">sql语句，如：select * from Users where Id=:Id</param>
        ///// <param name="parameter">参数，如：new { Id = 1 }</param>
        ///// <returns></returns>
        Task<List<T>> SqlQueryAsync<T>(string sql, object parameter) where T : class, new();
    }
}
