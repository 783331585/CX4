using Chloe.Entity;
using CX4.Domain.Entity;

namespace CX4.Chloe.Oracle
{
    /// <summary>
    /// 实体基类映射
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal abstract class EntityBaseMap<TEntity> : EntityTypeBuilder<TEntity> where TEntity : IEntityBase
    {
        /// <summary>
        /// 表名
        /// </summary>
        protected abstract string TableName { get; }

        /// <summary>
        /// Schema名       
        /// </summary>
        /// <remarks>默认值:<see cref="Schema_Prod_V1"/></remarks>
        protected virtual string Schema { get; } = Schema_Prod_V1;

        /// <summary>
        /// 序列号名称
        /// </summary>
        protected virtual string SeqName => $"{TableName.Replace("_t", "_s", System.StringComparison.CurrentCultureIgnoreCase)}";

        /// <summary>
        /// PROD_V1
        /// </summary>
        private const string Schema_Prod_V1 = "yungou_finc";
        public EntityBaseMap()
        {
            HasSchema(Schema);
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

    /// <summary>
    /// 聚合根基类映射
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal abstract class AggregateRootMap<TEntity> : EntityBaseMap<TEntity> where TEntity : IAggregateRoot
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
