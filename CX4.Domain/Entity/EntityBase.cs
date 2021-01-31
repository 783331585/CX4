using System;

namespace CX4.Domain.Entity
{
    /// <summary>
    /// 默认实体的抽象实现类
    /// </summary>
    public abstract class EntityBase : EntityBase<long>
    {
    }

    /// <summary>
    /// 实体的抽象实现类，定义实体的公共属性和行为
    /// </summary>
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual TKey ID { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public virtual long CreateID { get; set; } = 520;

        /// <summary>
        /// 创建者
        /// </summary>
        public virtual string CreateName { get; set; } = "pengdong";

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EntityBase<TKey>))
            {
                return false;
            }
            var compareTo = obj as EntityBase<TKey>;
            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }
            return ID.Equals(compareTo.ID);
        }

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool operator ==(EntityBase<TKey> source, EntityBase<TKey> target)
        {
            if (source is null && target is null)
            {
                return true;
            }
            if (source is null || target is null)
            {
                return false;
            }
            return source.Equals(target);
        }

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool operator !=(EntityBase<TKey> source, EntityBase<TKey> target)
        {
            return !(source == target);
        }

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + ID.GetHashCode();
        }

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{GetType().Name}-{ID}";
        }
    }
}
