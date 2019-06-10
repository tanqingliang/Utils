namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;

    /// <summary>
    /// 随机数
    /// </summary>
    public class RandomHelper
    {
        /// <summary>
        /// 字符集
        /// </summary>
        const string allChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        /// <summary>
        /// 字符集(字母)
        /// </summary>
        const string letterChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /// <summary>
        /// 字符集(数字)
        /// </summary>
        const string numberChars = "0123456789";

        /// <summary>
        /// 生成Guid
        /// </summary>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static string GenerateGuId(string format = null)
        {
            return Guid.NewGuid().ToString(format);
        }


        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string GenerateString(int length)
        {
            var bytes = new byte[length];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(bytes);
            }

            return new string(bytes.Select(x => allChars[x % allChars.Length]).ToArray());
        }

        /// <summary>
        /// 生成随机(字母)字符串
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string GenerateLetterString(int length)
        {
            var bytes = new byte[length];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(bytes);
            }

            return new string(bytes.Select(x => letterChars[x % letterChars.Length]).ToArray());
        }

        /// <summary>
        /// 生成随机(数字)字符串
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string GenerateNumberString(int length)
        {
            var bytes = new byte[length];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(bytes);
            }

            return new string(bytes.Select(x => numberChars[x % numberChars.Length]).ToArray());
        }


        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="MaxValue">最大值</param>
        /// <returns></returns>
        public static int GenerateNumber(int MaxValue)
        {
            return GenerateNumber(0, MaxValue);
        }
        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="minValue">最小值</param>
        /// <param name="MaxValue">最大值</param>
        /// <returns></returns>
        public static int GenerateNumber(int minValue, int MaxValue)
        {
            Random random = new Random();
            return random.Next(minValue, MaxValue);
        }



    }
}