namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Net;

    /// <summary>
    /// 时间工具
    /// </summary>
    public class TimeTools
    {

        /// <summary>
        /// 时间 -> 时间戳
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static long ToUnixTimeStamp(DateTime dt)
        {
            DateTimeOffset dto = new DateTimeOffset(dt);
            return dto.ToUnixTimeSeconds();
        }

        /// <summary>
        /// 时间戳 -> 时间
        /// </summary>
        /// <param name="unix">时间戳</param>
        /// <returns></returns>
        public static DateTime ToLocalTimeTime(long unix)
        {
            DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(unix);
            return dto.ToLocalTime().DateTime;
        }


        /// <summary>
        /// 判断是否今天
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static bool IsToday(DateTime dt)
        {
            return DateTime.Now.Date.Equals(dt.Date);
        }


        /// <summary>
        /// 获取周一
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static DateTime GetMonday(DateTime? dt = null)
        {
            if (!dt.HasValue)
            {
                dt = DateTime.Now;
            }

            if (dt.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                return dt.Value.AddDays(-6).Date;
            }
            else
            {
                return dt.Value.AddDays(1 - (int)dt.Value.DayOfWeek).Date;
            }
        }

        /// <summary>
        /// 获取月 -> 第一天
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static DateTime GetMonthFirstDay(DateTime? dt = null)
        {
            if (!dt.HasValue)
            {
                dt = DateTime.Now;
            }

            return dt.Value.AddDays(1 - dt.Value.Day).Date;
        }

        /// <summary>
        /// 获取季度 -> 第一天
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static DateTime GetQuarterFirstDay(DateTime? dt = null)
        {
            if (!dt.HasValue)
            {
                dt = DateTime.Now;
            }

            return dt.Value.AddMonths(0 - (dt.Value.Month - 1) % 3).AddDays(1 - dt.Value.Day).Date;
        }

        /// <summary>
        /// 获取年度 -> 第一天
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static DateTime GetYearsFirstDay(DateTime? dt = null)
        {
            if (!dt.HasValue)
            {
                dt = DateTime.Now;
            }

            return dt.Value.AddMonths(1 - dt.Value.Month).AddDays(1 - dt.Value.Day).Date;
        }

        /// <summary>
        /// 获取最近时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetFromNow(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;

            if (span.TotalDays > 60)
            {
                return dt.ToString("yyyy/MM/dd");
            }
            else if (span.TotalDays > 30)
            {
                return "1个月前";
            }
            else if (span.TotalDays > 14)
            {
                return "2周前";
            }
            else if (span.TotalDays > 7)
            {
                return "1周前";
            }
            else if (span.TotalDays > 1)
            {
                return $"{(int)span.TotalDays}天前";
            }
            else if (span.TotalHours > 1)
            {
                return $"{(int)span.TotalHours}小时前";
            }
            else if (span.TotalMinutes > 1)
            {
                return $"{(int)span.TotalMinutes}分钟前";
            }
            else if (span.TotalSeconds >= 1)
            {
                return $"{(int)span.TotalSeconds}秒前";
            }
            else
            {
                return "刚刚";
            }

        }

    }
}
