namespace Utils
{
    using System;

    /// <summary>
    /// (时间) 扩展属性
    /// </summary>
    public static partial class TimeExtensions
    {



        /// <summary>
        /// 时间 -> 时间戳
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static long ToUnixTimeStamp(this DateTime dt)
        {
            return TimeHelper.ToUnixTimeStamp(dt);
        }

        /// <summary>
        /// 时间戳 -> 时间
        /// </summary>
        /// <param name="unix">时间戳</param>
        /// <returns></returns>
        public static DateTime ToLocalTimeTime(this long unix)
        {
            return TimeHelper.ToLocalTimeTime(unix);
        }


        /// <summary>
        /// 判断是否今天
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static bool IsToday(this DateTime dt)
        {
            return TimeHelper.IsToday(dt);
        }


        /// <summary>
        /// 获取周一
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static DateTime GetMonday(this DateTime dt)
        {
            return TimeHelper.GetMonday(dt);
        }

        /// <summary>
        /// 获取月 -> 第一天
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static DateTime GetMonthFirstDay(this DateTime dt)
        {
            return TimeHelper.GetMonthFirstDay(dt);
        }

        /// <summary>
        /// 获取季度 -> 第一天
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static DateTime GetQuarterFirstDay(this DateTime dt)
        {
            return TimeHelper.GetQuarterFirstDay(dt);

        }

        /// <summary>
        /// 获取年度 -> 第一天
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static DateTime GetYearsFirstDay(this DateTime dt)
        {
            return TimeHelper.GetYearsFirstDay(dt);
        }

        /// <summary>
        /// 获取最近时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetFromNow(this DateTime dt)
        {
            return TimeHelper.GetFromNow(dt);
        }



    }
}