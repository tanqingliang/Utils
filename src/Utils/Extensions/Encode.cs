namespace Utils
{
    /// <summary>
    /// （加密) 扩展属性
    /// </summary>
    public static partial class Extensions
    {


        /// <summary>
        /// URL 编码
        /// </summary>
        /// <param name="input">编码内容</param>
        /// <returns></returns>
        public static string UrlEncode(this string input)
        {
            return Encode.UrlEncode(input);
        }
        /// <summary>
        /// URL 解码
        /// </summary>
        /// <param name="input">解码内容</param>
        /// <returns></returns>
        public static string UrlDecode(this string input)
        {
            return Encode.UrlDecode(input);
        }

        /// <summary>
        /// HTML 编码
        /// </summary>
        /// <param name="input">编码内容</param>
        /// <returns></returns>
        public static string HtmlEncode(this string input)
        {
            return Encode.HtmlEncode(input);
        }
        /// <summary>
        /// HTML 解码
        /// </summary>
        /// <param name="input">解码内容</param>
        /// <returns></returns>
        public static string HtmlDecode(this string input)
        {
            return Encode.HtmlDecode(input);
        }


        /// <summary>
        /// Base64 编码
        /// </summary>
        /// <param name="input">编码内容</param>
        /// <returns></returns>
        public static string Base64Encode(this string input)
        {
            return Encode.Base64Encode(input);
        }
        /// <summary>
        /// Base64 解码
        /// </summary>
        /// <param name="input">解码内容</param>
        /// <returns></returns>
        public static string Base64Decode(this string input)
        {
            return Encode.Base64Decode(input);
        }

    }
}