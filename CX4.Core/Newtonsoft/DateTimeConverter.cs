namespace Newtonsoft.Json.Converters
{
    /// <summary>
    /// yyyy-MM-dd格式m
    /// </summary>
    public class ShortDateConverter : IsoDateTimeConverter
    {
        public ShortDateConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }

    /// <summary>
    /// yyyy-MM-dd HH:ss:fff格式
    /// </summary>
    public class LongTimeConverter : IsoDateTimeConverter
    {
        public LongTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
