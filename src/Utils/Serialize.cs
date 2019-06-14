namespace Utils
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Net;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// 序列化
    /// </summary>
    public class Serialize
    {

        /// <summary>
        /// 对象 序列化 JSON字符串
        /// </summary>
        /// <param name="input">格式化对象</param>
        /// <returns></returns>
        public static string JsonSerializeObject<T>(T input)
        {
            return JsonConvert.SerializeObject(input);
        }
        /// <summary>
        /// 字符串 序列化 对象
        /// </summary>
        /// <param name="input">格式化JSON字符串</param>
        /// <typeparam name="T">对象泛型</typeparam>
        /// <returns></returns>
        public static T JsonDeserializeObject<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }


        /// <summary>
        /// XML序列化 JSON字符串
        /// </summary>
        /// <param name="input">格式化XML字符串</param>
        /// <returns></returns>
        public static string JsonSerializeXmlNode(string input)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(input);

            return JsonSerializeXmlNode(xml);
        }
        /// <summary>
        /// XML序列化 JSON字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string JsonSerializeXmlNode(XmlNode input)
        {
            return JsonConvert.SerializeXmlNode(input);
        }
        /// <summary>
        /// JSON字符 序列化 XML
        /// </summary>
        /// <param name="input">格式化JSON字符串</param>
        /// <returns></returns>
        public static XmlNode JsonDeserializeXmlNode(string input)
        {
            return JsonConvert.DeserializeXmlNode(input);
        }




        /// <summary>
        /// /// <summary>
        /// 对象 序列化 XML字符串
        /// </summary>
        /// <param name="input">格式化对象</param>
        /// <typeparam name="T">对象泛型</typeparam>
        /// <returns></returns>
        public static string XmlSerializeObject<T>(T input)
        {
            var type = typeof(T);

            if (type.IsConstructedGenericType)
            {
                throw new FormatException("必须使用构造型泛型");
            }

            XmlSerializer s = new XmlSerializer(type);

            using (MemoryStream memStream = new MemoryStream())
            {

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);
                s.Serialize(memStream, input, namespaces);

                return Encoding.UTF8.GetString(memStream.ToArray());
            }
        }

        /// <summary>
        /// XML 序列化 对象
        /// </summary>
        /// <param name="input">格式化对象</param>
        /// <typeparam name="T">对象泛型</typeparam>
        /// <returns></returns>
        public static T XmlDeserializeObject<T>(string input)
        {
            var data = Encoding.UTF8.GetBytes(input);
            using (MemoryStream stream = new MemoryStream(data))
            {
                return XmlDeserializeObject<T>(stream);
            }
        }
        /// <summary>
        /// XML 序列化 对象
        /// </summary>
        /// <param name="input">格式化对象</param>
        /// <typeparam name="T">对象泛型</typeparam>
        /// <returns></returns>
        public static T XmlDeserializeObject<T>(Stream input)
        {
            var type = typeof(T);

            if (type.IsConstructedGenericType)
            {
                throw new FormatException("必须使用构造型泛型");
            }

            XmlSerializer s = new XmlSerializer(type);
            return (T)s.Deserialize(input);
        }

    }
}