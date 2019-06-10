namespace Utils
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using OfficeOpenXml;
    using OfficeOpenXml.Table;
    using System.Reflection;

    /// <summary>
    /// 导出
    /// </summary>
    public class ExportHelper
    {



        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="filePath">保存文件目录</param>
        /// <param name="data">数据</param>
        /// <typeparam name="T">泛型</typeparam>
        public static void Excel<T>(string filePath, List<T> data)
        {
            //创建文件
            using (FileStream fs = File.Create(filePath))
            {
                using (var excel = new ExcelPackage(fs))
                {
                    // 添加表格内容
                    AddWorkSheet(excel, "sheet1", data);

                    // 保存
                    excel.Save();
                }

                // 关闭文件流
                fs.Close();
            }
        }




        /// <summary>
        /// 添加表格内容
        /// </summary>
        /// <param name="excel">excel</param>
        /// <param name="sheetName">sheet</param>
        /// <param name="data">内容</param>
        /// <typeparam name="T">泛型</typeparam>
        public static void AddWorkSheet<T>(ExcelPackage excel, string sheetName, List<T> data)
        {
            var worksheet = excel.Workbook.Worksheets.Add(sheetName);

            // 泛型字段            
            PropertyInfo[] properties = typeof(T).GetProperties();

            // 表格头部
            var fields = new Dictionary<string, string>();
            for (int i = 0; i < properties.Length; i++)
            {
                fields.Add(properties[i].Name, properties[i].Name);
            }
            for (int i = 0; i < fields.Keys.Count; i++)
            {
                var key = fields.Keys.ToList()[i];
                worksheet.Cells[1, i + 1].Value = fields[key];
            }

            // 表格内容
            int filedCount = fields.Count;
            for (int i = 0; i < data.Count; i++)
            {
                var item = data[i];

                for (int j = 0; j < filedCount; j++)
                {
                    var key = fields.Keys.ToList()[j];
                    var obj = properties.First(w => w.Name == key);

                    if (obj != null)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = ShowValue(obj.GetValue(item, null));
                    }
                }
            }
        }




        /// <summary>
        /// 转换成表格显示格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static object ShowValue<T>(T value)
        {
            if (value == null)
            {
                return value;
            }

            switch (value.GetType().Name.ToLower())
            {
                case "int16":
                case "uint16":
                case "int32":
                case "uint32":
                case "int64":
                case "uint64":
                    return Convert.ToInt64(value);


                case "double":
                case "decimal":
                    return Convert.ToDouble(value);


                case "byte":
                case "sbyte":
                case "char":
                case "boolean":
                case "guid":
                case "timespan":
                case "single":
                case "datetime":
                default:
                    return Convert.ToString(value);

            }
        }



    }
}