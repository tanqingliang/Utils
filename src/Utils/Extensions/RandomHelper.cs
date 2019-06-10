namespace Utils
{
    /// <summary>
    /// （随机数) 扩展属性
    /// </summary>
    public static partial class RandomExtensions
    {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string GenerateString(this int length)
        {
            return RandomHelper.GenerateString(length);
        }


        /// <summary>
        /// 生成随机(字母)字符串
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string GenerateLetterString(this int length)
        {
            return RandomHelper.GenerateLetterString(length);
        }

        /// <summary>
        /// 生成随机(数字)字符串
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string GenerateNumberString(this int length)
        {
            return RandomHelper.GenerateNumberString(length);
        }


        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="MaxValue">最大值</param>
        /// <returns></returns>
        public static int GenerateNumber(this int MaxValue)
        {
            return RandomHelper.GenerateNumber(MaxValue);
        }



    }
}