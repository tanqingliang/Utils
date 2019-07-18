namespace Utils.Extensions
{
    using System;

    /// <summary>
    /// (字符串) 扩展方法
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// 字符串 -> double
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double ToDouble(this string input)
        {
            double value;
            double.TryParse(input, out value);
            return value;
        }

        /// <summary>
        /// 字符串 -> int
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int ToInt(this string input)
        {
            int value;
            int.TryParse(input, out value);
            return value;
        }

        /// <summary>
        /// 字符串 -> long
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static long ToLong(this string input)
        {
            long value;
            long.TryParse(input, out value);
            return value;
        }


        /// <summary>
        /// 字符串 -> DateTime
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime value;
            DateTime.TryParse(input, out value);
            return value;
        }

    }
}