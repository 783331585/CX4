using System;

namespace CX4.Domain.Entity
{
    /// <summary>
    /// 默认聚合根的抽象实现类
    /// </summary>
    public abstract class AggregateRoot : AggregateRoot<long>
    {
    }

    /// <summary>
    /// 聚合根的抽象实现类，定义聚合根的公共属性和行为
    /// </summary>
    public abstract class AggregateRoot<TKey> : EntityBase<TKey>, IAggregateRoot<TKey>
    {
        /// <summary>
        /// 最后修改用户
        /// </summary>
        public virtual string LastUpdateName { get; set; } = "pengdong";

        /// <summary>
        /// 最后修改用户主键
        /// </summary>
        public virtual long LastUpdateID { get; set; } = 520;

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime LastUpdateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新最后修改信息
        /// </summary>
        public void SetLastUpdate()
        {
            this.LastUpdateDate = DateTime.Now;
            this.LastUpdateID = 520;
            this.LastUpdateName = "pengdong";
        }
    }
}
