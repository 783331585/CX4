using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CX4.Core.Extensions
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取字典集合的枚举集合
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<KeyValuePair<int, string>> GetEnumKeyValuePair(this Type type)
        {
            IDictionary<int, string> dic = new Dictionary<int, string>();
            if (type.IsEnum)
            {
                FieldInfo[] fieldInfoList = type.GetFields();
                var query = fieldInfoList.Where(k => GetDescription(k).Length > 0);
                foreach (var item in query)
                {
                    dic.Add(Convert.ToInt32(item.GetValue(null)), GetDescription(item)[0].Description);
                }
            }
            return dic.ToList();
        }

        /// <summary>
        /// 获取指定枚举类型获取值
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static int GetValue(this Enum e)
        {
            Type t = e.GetType();
            FieldInfo fieldInfo = t.GetField(e.ToString());
            int retVlaue = (int)fieldInfo.GetValue(null);
            return retVlaue;
        }

        /// <summary>
        /// 获取指定枚举类型获取描叙信息
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum e)
        {
            Type t = e.GetType();
            FieldInfo fieldInfo = t.GetField(e.ToString());
            DescriptionAttribute[] desc = GetDescription(fieldInfo);
            return desc.Length > 0 ? desc[0].Description : null;
        }

        /// <summary>
        /// 根据字段获取枚举描叙信息
        /// </summary>
        /// <param name="fieldInfo"></param>
        /// <returns></returns>
        private static DescriptionAttribute[] GetDescription(FieldInfo fieldInfo)
        {
            DescriptionAttribute[] desc = null;
            if (fieldInfo != null)
            {
                desc = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            }
            return desc;
        }
    }
}
