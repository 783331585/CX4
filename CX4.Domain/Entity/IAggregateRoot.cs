using System;

namespace CX4.Domain.Entity
{
    /// <summary>
    /// 聚合根接口，用作泛型约束，约束领域实体为聚合根，表示实现了该接口的为聚合根实例，由于聚合根也是领域实体的一种，所以也要实现IEntity接口
    /// </summary>
    public interface IAggregateRoot : IEntityBase
    {

        /// <summary>
        /// 最后修改用户主键
        /// </summary>
        long LastUpdateID { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        string LastUpdateName { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime LastUpdateDate { get; set; }
    }

    /// <summary>
    ///  聚合根接口，用作泛型约束，约束领域实体为聚合根，表示实现了该接口的为聚合根实例，由于聚合根也是领域实体的一种，所以也要实现IEntity接口
    /// </summary>
    public interface IAggregateRoot<TKey> : IEntityBase<TKey>, IAggregateRoot
    {
    }
}
