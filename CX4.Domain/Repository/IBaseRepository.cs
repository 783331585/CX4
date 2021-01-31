using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CX4.Domain.Entity;

namespace CX4.Domain.Repository
{
    /// <summary>
    /// 仓储层默认接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, long> where TEntity : IEntityBase<long>
    {
    }

    /// <summary>
    /// 仓储层接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IBaseRepository<TEntity, TKey> where TEntity : IEntityBase<TKey>
    {

        #region 新增

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entities"></param>
        void InsertRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entities"></param>
        Task InsertRangeAsync(IEnumerable<TEntity> entities);

        #endregion 新增

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        bool Delete(TKey key);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        Task<bool> DeleteAsync(TKey key);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="predicate"></param>
        bool Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="predicate"></param>
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion 删除

        #region 更新

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        bool Update(TEntity entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        Task<bool> UpdateAsync(TEntity entity);

        #endregion 更新

        #region 查找

        /// <summary>
        /// 根据条件查找
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据条件查找
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 查找根据主键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity Get(TKey key);

        /// <summary>
        ///查找根据主键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TKey key);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        List<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 采取指定数量的数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<TEntity> Take(Expression<Func<TEntity, bool>> predicate, int count);

        /// <summary>
        /// 采取指定数量的数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<List<TEntity>> TakeAsync(Expression<Func<TEntity, bool>> predicate, int count);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<TEntity> TakePage(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<TEntity>> TakePageAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetAllList();

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllListAsync();

        #endregion 查找

        #region 统计

        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 合计
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        decimal Sum(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, decimal>> selector);

        /// <summary>
        /// 合计
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        Task<decimal> SumAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, decimal>> selector);

        /// <summary>
        /// 合计
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        int Sum(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> selector);

        /// <summary>
        /// 合计
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        Task<int> SumAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> selector);

        /// <summary>
        /// 最小值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        TResult Min<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector);

        /// <summary>
        /// 最小值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        Task<TResult> MinAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector);

        /// <summary>
        /// 最大值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        TResult Max<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector);

        /// <summary>
        /// 最大值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        Task<TResult> MaxAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector);

        /// <summary>
        /// 平均
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        decimal? Average(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, decimal>> selector);

        /// <summary>
        /// 平均
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        Task<decimal?> AverageAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, decimal>> selector);

        #endregion

        #region 验证
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Exist(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion

    }
}
