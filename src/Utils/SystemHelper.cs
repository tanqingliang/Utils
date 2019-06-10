namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// 系统
    /// </summary>
    public class SystemHelper
    {

        /// <summary>
        /// 获取客户真实Ip
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetClientIP(HttpContext t)
        {
            if (t.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return t.Request.Headers["X-Forwarded-For"].ToString();
            }
            else if (t.Request.Headers.ContainsKey("X-Real-IP"))
            {
                return t.Request.Headers["X-Real-IP"].ToString();
            }
            else
            {
                return t.Connection.RemoteIpAddress.ToString();
            }
        }


        // /// <summary>
        // /// 获取操作系统
        // /// </summary>
        // /// <returns></returns>
        // public static string GetSystemName()
        // {
        //     // if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        //     // {
        //     //     return "Linux";
        //     // }
        //     // else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        //     // {
        //     //     return "Windows";
        //     // }
        //     // else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        //     // {
        //     //     return "OSX";
        //     // }
        //     // else
        //     // {
        //     //     return "Other";
        //     // }
        //     return RuntimeInformation.OSDescription;
        // }

    }
}