namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Net;

    /// <summary>
    /// 文件工具类
    /// </summary>
    public class FileHelper
    {


        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        /// <summary>
        /// 获取目录下 -> 文件列表
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="subdirectories">是否查找子目录</param>
        /// <returns></returns>
        public static string[] GetDirectoryFiles(string path, bool subdirectories = false)
        {
            if (!Directory.Exists(path))
            {
                throw new FileNotFoundException("目录不存在");
            }
            if (!subdirectories)
            {
                return Directory.GetFiles(path);
            }
            
            string[] data = new string[0];

            // 子目录
            var directories = Directory.GetDirectories(path);
            foreach (var item in directories)
            {
                data = data.Concat(GetDirectoryFiles(item, true)).ToArray();
            }

            data = data.Concat(Directory.GetFiles(path)).ToArray();

            return data;
        }


    }
}