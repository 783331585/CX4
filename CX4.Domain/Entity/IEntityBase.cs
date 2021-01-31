using System;

namespace CX4.Domain.Entity
{
    /// <summary>
    /// 领域实体接口
    /// </summary>
    public interface IEntityBase
    {

        /// <summary>
        /// 创建者ID
        /// </summary>
        long CreateID { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        string CreateName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreateDate { get; set; }
    }

    /// <summary>
    ///  用作泛型约束，表示继承自该接口的为领域实体
    /// </summary>
    /// <typeparam name="TKey">主键</typeparam>
    public interface IEntityBase<TKey> : IEntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        TKey ID { get; set; }
    }

}
