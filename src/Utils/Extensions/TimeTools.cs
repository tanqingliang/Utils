namespace Utils
{
    using System;

    /// <summary>
    /// (时间) 扩展属性
    /// </summary>
    public static partial class Extensions
    {



        /// <summary>
        /// 时间 -> 时间戳
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static long ToUnixTimeStamp(this DateTime dt)
        {
            return TimeTools.ToUnixTimeStamp(dt);
        }

        /// <summary>
        /// 时间戳 -> 时间
        /// </summary>
        /// <param name="unix">时间戳</param>
        /// <returns></returns>
        public static DateTime ToLocalTimeTime(this long unix)
        {
            return TimeTools.ToLocalTimeTime(unix);
        }


        /// <summary>
        /// 判断是否今天
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static bool IsToday(this DateTime dt)
        {
            return TimeTools.IsToday(dt);
        }


        /// <summary>
        /// 获取周一
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static DateTime GetMonday(this DateTime dt)
        {
            return TimeTools.GetMonday(dt);
        }

        /// <summary>
        /// 获取月 -> 第一天
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static DateTime GetMonthFirstDay(this DateTime dt)
        {
            return TimeTools.GetMonthFirstDay(dt);
        }

        /// <summary>
        /// 获取季度 -> 第一天
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static DateTime GetQuarterFirstDay(this DateTime dt)
        {
            return TimeTools.GetQuarterFirstDay(dt);

        }

        /// <summary>
        /// 获取年度 -> 第一天
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static DateTime GetYearsFirstDay(this DateTime dt)
        {
            return TimeTools.GetYearsFirstDay(dt);
        }

        /// <summary>
        /// 获取最近时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetFromNow(this DateTime dt)
        {
            return TimeTools.GetFromNow(dt);
        }



    }
}