namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Net;

    /// <summary>
    /// 编码
    /// </summary>
    public class Encode
    {

        /// <summary>
        /// URL 编码
        /// </summary>
        /// <param name="input">编码内容</param>
        /// <returns></returns>
        public static string UrlEncode(string input)
        {
            return WebUtility.UrlEncode(input);
        }
        /// <summary>
        /// URL 解码
        /// </summary>
        /// <param name="input">解码内容</param>
        /// <returns></returns>
        public static string UrlDecode(string input)
        {
            return WebUtility.UrlDecode(input);
        }

        /// <summary>
        /// HTML 编码
        /// </summary>
        /// <param name="input">编码内容</param>
        /// <returns></returns>
        public static string HtmlEncode(string input)
        {
            return WebUtility.HtmlEncode(input);
        }
        /// <summary>
        /// HTML 解码
        /// </summary>
        /// <param name="input">解码内容</param>
        /// <returns></returns>
        public static string HtmlDecode(string input)
        {
            return WebUtility.HtmlDecode(input);
        }


        /// <summary>
        /// Base64 编码
        /// </summary>
        /// <param name="input">编码内容</param>
        /// <returns></returns>
        public static string Base64Encode(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// Base64 解码
        /// </summary>
        /// <param name="input">解码内容</param>
        /// <returns></returns>
        public static string Base64Decode(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            byte[] bytes = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}