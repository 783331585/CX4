using Chloe.Entity;
using CX4.Domain.Entity;

namespace CX4.Chloe.FluentMapping
{
    /// <summary>
    /// 实体基类映射
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityBaseMap<TEntity> : EntityTypeBuilder<TEntity> where TEntity : IEntityBase
    {
        /// <summary>
        /// 表名
        /// </summary>
        protected abstract string TableName { get; }

        public EntityBaseMap()
        {
            MapTo(TableName);
            Property(k => k.CreateName).MapTo("Create_Name");
            Property(k => k.CreateID).MapTo("Create_By");
            Property(k => k.CreateDate).MapTo("Create_Date");
        }

        /// <summary>
        /// 忽略实体中创建者信息映射
        /// </summary>
        protected void IgnoreCreateMap()
        {
            Ignore(k => k.CreateName);
            Ignore(k => k.CreateID);
            Ignore(k => k.CreateDate);
        }
    }
}
