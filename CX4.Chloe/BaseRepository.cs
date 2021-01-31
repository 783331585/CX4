using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Chloe;
using CX4.Domain.Entity;
using CX4.Domain.Repository;

namespace CX4.Chloe
{
    /// <inheritdoc cref="IBaseRepository{TEntity}"/>
    public class BaseRepository<TEntity> : BaseRepository<TEntity, long>, IBaseRepository<TEntity> where TEntity : IEntityBase<long>
    {
        public BaseRepository(IDbReaderContext readerContext, IDbWriterContext writerContent) : base(readerContext, writerContent)
        {
        }
    }

    /// <inheritdoc cref="IBaseRepository{TEntity, TKey}"/>
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : IEntityBase<TKey>
    {
        private readonly IDbContext _reader;
        private readonly IDbContext _writer;

        public BaseRepository(IDbReaderContext readerContext, IDbWriterContext writerContent)
        {
            _reader = readerContext;
            _writer = writerContent;
        }

        #region 新增
        public TEntity Insert(TEntity entity)
        {
            return _writer.Insert(entity);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            return await _writer.InsertAsync(entity);
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            _writer.InsertRange(entities.ToList());
        }

        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await _writer.InsertRangeAsync(entities.ToList());
        }
        #endregion

        #region 删除
        public bool Delete(TKey key)
        {
            return _writer.DeleteByKey<TEntity>(key) > 0;
        }

        public async Task<bool> DeleteAsync(TKey key)
        {
            return await _writer.DeleteByKeyAsync<TEntity>(key) > 0;
        }

        public bool Delete(Expression<Func<TEntity, bool>> predicate)
        {
            return _writer.Delete(predicate) > 0;
        }

        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _writer.DeleteAsync(predicate) > 0;
        }
        #endregion

        #region 更新
        public bool Update(TEntity entity)
        {
            return _writer.Update(entity) > 0;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await _writer.UpdateAsync(entity) > 0;
        }
        #endregion

        #region 查询

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _reader.Query<TEntity>().Where(predicate).FirstOrDefault();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _reader.Query<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public TEntity Get(TKey key)
        {
            return _reader.QueryByKey<TEntity>(key);
        }

        public async Task<TEntity> GetAsync(TKey key)
        {
            return await _reader.QueryByKeyAsync<TEntity>(key);
        }

        public List<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return _reader.Query<TEntity>().Where(predicate).ToList();
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _reader.Query<TEntity>().Where(predicate).ToListAsync();
        }

        public List<TEntity> Take(Expression<Func<TEntity, bool>> predicate, int count)
        {
            return _reader.Query<TEntity>().Where(predicate).Take(count).ToList();
        }

        public async Task<List<TEntity>> TakeAsync(Expression<Func<TEntity, bool>> predicate, int count)
        {
            return await _reader.Query<TEntity>().Where(predicate).Take(count).ToListAsync();
        }

        public List<TEntity> TakePage(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize)
        {
            return _reader.Query<TEntity>().Where(predicate).TakePage(pageIndex, pageSize).OrderByDesc(k => k.ID).ToList();
        }

        public async Task<List<TEntity>> TakePageAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize)
        {
            return await _reader.Query<TEntity>().Where(predicate).TakePage(pageIndex, pageSize).OrderByDesc(k => k.ID).ToListAsync();
        }

        public List<TEntity> GetAllList()
        {
            return _reader.Query<TEntity>().ToList();
        }

        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await _reader.Query<TEntity>().ToListAsync();
        }

        #endregion

        #region 统计

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _reader.Query<TEntity>().Where(predicate).Count();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _reader.Query<TEntity>().Where(predicate).CountAsync();
        }

        public decimal Sum(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, decimal>> selector)
        {
            return _reader.Query<TEntity>().Where(predicate).Sum(selector);
        }

        public async Task<decimal> SumAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, decimal>> selector)
        {
            return await _reader.Query<TEntity>().Where(predicate).SumAsync(selector);
        }

        public int Sum(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> selector)
        {
            return _reader.Query<TEntity>().Where(predicate).Sum(selector);
        }

        public async Task<int> SumAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> selector)
        {
            return await _reader.Query<TEntity>().Where(predicate).SumAsync(selector);
        }

        public TResult Min<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            return _reader.Query<TEntity>().Where(predicate).Min(selector);
        }

        public async Task<TResult> MinAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            return await _reader.Query<TEntity>().Where(predicate).MinAsync(selector);
        }

        public TResult Max<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            return _reader.Query<TEntity>().Where(predicate).Max(selector);
        }

        public async Task<TResult> MaxAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            return await _reader.Query<TEntity>().Where(predicate).MaxAsync(selector);
        }

        public decimal? Average(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, decimal>> selector)
        {
            return _reader.Query<TEntity>().Where(predicate).Average(selector);
        }

        public async Task<decimal?> AverageAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, decimal>> selector)
        {
            return await _reader.Query<TEntity>().Where(predicate).AverageAsync(selector);
        }

        #endregion

        #region 验证
        public bool Exist(Expression<Func<TEntity, bool>> predicate)
        {
            return _reader.Query<TEntity>().Any(predicate);
        }

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _reader.Query<TEntity>().AnyAsync(predicate);
        }
        #endregion
    }
}
