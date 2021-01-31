using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace CX4.Core.Extensions
{
    /// <summary>
    /// Json操作
    /// </summary>
    public static class JsonExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static object ToJson(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="dateTimeFormat"></param>
        /// <returns></returns>
        public static string ToJson(this object obj, string dateTimeFormat)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = dateTimeFormat };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string json)
        {
            return json == null ? default : JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this string json)
        {
            return json == null ? new List<T>() : JsonConvert.DeserializeObject<List<T>>(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JObject ToJObject(this string json)
        {
            return json == null ? JObject.Parse("{}") : JObject.Parse(json.Replace("&nbsp;", ""));
        }
    }
}
