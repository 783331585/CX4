using CX4.Domain.Entity;

namespace CX4.Chloe.FluentMapping
{
    /// <summary>
    /// 聚合根基类映射
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class AggregateRootMap<TEntity> : EntityBaseMap<TEntity> where TEntity : IAggregateRoot
    {
        public AggregateRootMap()
        {
            Property(k => k.LastUpdateName).MapTo("Last_Update_Name");
            Property(k => k.LastUpdateID).MapTo("Last_Update_By");
            Property(k => k.LastUpdateDate).MapTo("Last_Update_Date");
        }

        /// <summary>
        /// 忽略实体中最后更新者信息映射
        /// </summary>
        protected void IgnoreLastUpdateMap()
        {
            Ignore(k => k.LastUpdateID);
            Ignore(k => k.LastUpdateName);
            Ignore(k => k.LastUpdateDate);
        }
    }
}
