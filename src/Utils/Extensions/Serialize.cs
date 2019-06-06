namespace Utils
{
    using System.Xml;

    /// <summary>
    /// （序列化) 扩展属性
    /// </summary>
    public static partial class Extensions
    {



        /// <summary>
        /// 对象 序列化 JSON字符串
        /// </summary>
        /// <param name="input">格式化对象</param>
        /// <returns></returns>
        public static string JsonSerializeObject<T>(this T input)
        {
            return Serialize.JsonSerializeObject(input);
        }
        /// <summary>
        /// 字符串 序列化 对象
        /// </summary>
        /// <param name="input">格式化JSON字符串</param>
        /// <typeparam name="T">对象泛型</typeparam>
        /// <returns></returns>
        public static T JsonDeserializeObject<T>(this string input)
        {
            return Serialize.JsonDeserializeObject<T>(input);
        }

        /// <summary>
        /// XML序列化 JSON字符串
        /// </summary>
        /// <param name="input">格式化XML字符串</param>
        /// <returns></returns>
        public static string JsonSerializeXmlNode(this string input)
        {
            return Serialize.JsonSerializeXmlNode(input);
        }
        /// <summary>
        /// XML序列化 JSON字符串
        /// </summary>
        /// <param name="input">格式化XML字符串</param>
        /// <returns></returns>
        public static string JsonSerializeXmlNode(this XmlNode input)
        {
            return Serialize.JsonSerializeXmlNode(input);
        }
        /// <summary>
        /// JSON字符 序列化 XML
        /// </summary>
        /// <param name="input">格式化JSON字符串</param>
        /// <returns></returns>
        public static XmlNode JsonDeserializeXmlNode(this string input)
        {
            return Serialize.JsonDeserializeXmlNode(input);
        }




        /// <summary>
        /// /// <summary>
        /// 对象 序列化 XML字符串
        /// </summary>
        /// <param name="input">格式化对象</param>
        /// <typeparam name="T">对象泛型</typeparam>
        /// <returns></returns>
        public static string XmlSerializeObject<T>(this T input)
        {
            return Serialize.XmlSerializeObject(input);
        }

        /// <summary>
        /// XML 序列化 对象
        /// </summary>
        /// <param name="input">格式化对象</param>
        /// <typeparam name="T">对象泛型</typeparam>
        /// <returns></returns>
        public static T XmlDeserializeObject<T>(this string input)
        {
            return Serialize.XmlDeserializeObject<T>(input);
        }


    }
}