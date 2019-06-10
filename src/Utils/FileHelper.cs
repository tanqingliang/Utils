namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.IO.Compression;
    using System.Net;

    /// <summary>
    /// 文件工具类
    /// </summary>
    public class FileHelper
    {

        // 图片后缀名
        static string[] imageExts = new string[] { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };
        // 视频后缀名
        static string[] videoExts = new string[] { ".flv", ".swf", ".mkv", ".avi", ".rm", ".rmvb", ".mpeg", ".mpg", ".ogg", ".ogv", ".mov", ".wmv", ".mp4", ".webm", ".mp3", ".wav", ".mid" };


        /// <summary>
        /// 判断是否图片文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsImage(string fileName)
        {
            var ext = Path.GetExtension(fileName).ToLower();

            return imageExts.Where(w => w == ext).Count() > 0;
        }

        /// <summary>
        /// 判断是否视频文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsVideo(string fileName)
        {
            var ext = Path.GetExtension(fileName).ToLower();

            return videoExts.Where(w => w == ext).Count() > 0;
        }



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


        /// <summary>
        /// 目录复制
        /// </summary>
        /// <param name="sourceDirName">源目录</param>
        /// <param name="destDirName">目标目录</param>
        /// <param name="copySubDirs">是否复制子目录</param>
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs = true)
        {
            // 获取源目录
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("原目录文件不存在 " + sourceDirName);
            }

            // 创建目标目录
            CreateDirectory(destDirName);


            // 获取目录中的文件并将其复制到新位置。
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // 判断是否复制子目录
            if (copySubDirs)
            {
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }


        /// <summary>
        /// 创建zip压缩文件
        /// </summary>
        /// <param name="sourceDirPath">源目录</param>
        /// <param name="sourceFilePath">源文件</param>
        /// <param name="zipPath">压缩文件</param>
        public static void CreateZipFile(string[] sourceDirPath, string[] sourceFilePath, string zipPath)
        {
            // 临时目录
            var tempPath = System.IO.Path.GetFullPath("./temp/" + RandomHelper.GenerateGuId());
            Console.WriteLine(tempPath);

            // 创建临时目录
            CreateDirectory(tempPath);


            // 复制到临时目录
            if (sourceDirPath != null)
            {
                foreach (var path in sourceDirPath)
                {
                    DirectoryCopy(path, tempPath, true);
                }
            }
            if (sourceFilePath != null)
            {
                foreach (var path in sourceFilePath)
                {
                    File.Copy(path, tempPath);
                }
            }

            // 临时目录压缩
            ZipFile.CreateFromDirectory(tempPath, zipPath);

            // 删除临时目录           
            Directory.Delete(tempPath, true);
        }


    }
}