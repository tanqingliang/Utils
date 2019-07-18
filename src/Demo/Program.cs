using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.IO;
using Utils;
using Utils.Extensions;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            TestModel obj = null;

            Console.WriteLine($"Name -> {obj?.Name}");
            obj = new TestModel() { Name = "test" };
            Console.WriteLine($"Name -> {obj?.Name}");

            // 随机生成
            // Console.WriteLine($"GenerateGuId: {Randoms.GenerateGuId("n")}");
            // Console.WriteLine($"GenerateString: {Randoms.GenerateString(10)}");
            // Console.WriteLine($"GenerateLetterString: {Randoms.GenerateLetterString(10)}");
            // Console.WriteLine($"GenerateNumberString: {Randoms.GenerateNumberString(10)}");
            // Console.WriteLine($"GenerateNumber: {Randoms.GenerateNumber(10)}");


            // 加密
            // string key = "98765432", value = "qwertyui";

            // Console.WriteLine($"HashMd5: {value.HashMd5()}");

            // Console.WriteLine($"HashSha1: {value.HashSha1()}");
            // Console.WriteLine($"HashSha256: {value.HashSha256()}");
            // Console.WriteLine($"HashSha384: {value.HashSha384()}");
            // Console.WriteLine($"HashSha512: {value.HashSha512()}");

            // Console.WriteLine($"HashHmacSha1: {value.HashHmacSha1(key)}");
            // Console.WriteLine($"HashHmacSha256: {value.HashHmacSha256(key)}");
            // Console.WriteLine($"HashHmacSha384: {value.HashHmacSha384(key)}");
            // Console.WriteLine($"HashHmacSha512: {value.HashHmacSha512(key)}");
            // Console.WriteLine($"HashHmacMd5: {value.HashHmacMd5(key)}");

            // var data = CryptHelper.DesEncrypt(key, key, value);
            // Console.WriteLine($"DesEncrypt: {data}");
            // Console.WriteLine($"DesDecrypt: {CryptHelper.DesDecrypt(key, value, data)}");


            // key = "1234567812345678";
            // data = CryptHelper.AesEncrypt(key, "cc0af0a73f56a604545b47e34f56efeb966e6a76");
            // Console.WriteLine($"AesEncrypt: {data}");
            // Console.WriteLine($"AesDecrypt: {CryptHelper.AesDecrypt(key, data)}");


            // var data = "https://open.weixin.qq.com/cgi-bin/showdocument?action=dir_list";
            // Console.WriteLine($"data: {data}");

            // data = Encode.UrlEncode(data);
            // Console.WriteLine($"UrlEncode: {data}");
            // data = Encode.UrlDecode(data);
            // Console.WriteLine($"DesEncrypt: {data}");

            // data=Encode.HtmlEncode(data);
            // Console.WriteLine($"HtmlEncode: {data}");
            // data = Encode.HtmlDecode(data);
            // Console.WriteLine($"HtmlDecode: {data}");


            // data=Encode.Base64Encode(data);
            // Console.WriteLine($"Base64Encode: {data}");
            // data = Encode.Base64Decode(data);
            // Console.WriteLine($"Base64Decode: {data}");


            // var obj = new TestModel()
            // {
            //     Name = "test"
            // };
            // var data = Serialize.JsonSerializeObject(obj);
            // Console.WriteLine($"JsonSerializeObject: {data}");
            // obj = Serialize.JsonDeserializeObject<TestModel>(data);
            // Console.WriteLine($"JsonDeserializeObject: {obj.Name}");

            // Console.WriteLine($"JsonDeserializeXmlNode: {Serialize.JsonDeserializeXmlNode(data)}");


            // data = Serialize.XmlSerializeObject(obj);
            // Console.WriteLine($"XmlSerializeObject: {data}");

            // Console.WriteLine($"JsonSerializeXmlNode: {Serialize.JsonSerializeXmlNode(data)}");

            // var newObj = Serialize.XmlDeserializeObject<TestModel>(data);
            // Console.WriteLine($"XmlDeserializeObject: {newObj.Name}");

            // var dt = DateTime.Now;
            // Console.WriteLine($"dt: {dt}");
            // var data = TimeHelper.ToUnixTimeStamp(dt);
            // Console.WriteLine($"ToUnixTimeStamp: {data}");
            // dt = TimeHelper.ToLocalTimeTime(data);
            // Console.WriteLine($"ToLocalTimeTime: {dt}");
            // dt = DateTime.Parse("2019-07-01");
            // Console.WriteLine($"IsToday: {TimeHelper.IsToday(dt)}");
            // Console.WriteLine($"GetMonday: {TimeHelper.GetMonday(dt)}");
            // Console.WriteLine($"GetMonthFirstDay: {TimeHelper.GetMonthFirstDay(dt)}");
            // Console.WriteLine($"GetQuarterFirstDay: {TimeHelper.GetQuarterFirstDay(dt)}");
            // Console.WriteLine($"GetYearsFirstDay: {TimeHelper.GetYearsFirstDay(dt)}");


            // var path = "/Users/tanqingliang/Project/Utils/src/Demo";
            // var data = FileHelper.GetDirectoryFiles(path);
            // Console.WriteLine($"GetDirectoryFiles：{data.JsonSerializeObject()}");
            // data = FileHelper.GetDirectoryFiles(path, true);
            // Console.WriteLine($"GetDirectoryFiles：{data.JsonSerializeObject()}");

            // FileHelper.CreateZipFile(new string[] { "/Users/tanqingliang/Downloads/Paket/.paket" }, new string[] { "/Users/tanqingliang/Project/Utils/src/Utils/csproj" }, $"/Users/tanqingliang/Project/Utils/src/Demo/temp/{RandomHelper.GenerateGuId()}.zip");


            // 导出
            // ExportHelper.Excel("./test.xlsx", data);
            // ExportHelper.Excel("./test.xlsx", new Dictionary<string);

            // 图片
            // ImageHelper.GenerateVerifyCode("./verifycode.jpg", "1234");
            // ImageHelper.GenerateQRCode("./qrcode.jpg", "呵呵", QRCoder.QRCodeGenerator.ECCLevel.H, true, false);




        }
    }

    public class TestModel
    {
        public string Name { set; get; }
    }
}
