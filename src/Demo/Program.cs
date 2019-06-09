using System;
using System.Security.Cryptography;
using Utils;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {


            // 随机生成
            // Console.WriteLine($"GenerateGuId: {Utils.Randoms.GenerateGuId("n")}");
            // Console.WriteLine($"GenerateString: {Utils.Randoms.GenerateString(10)}");
            // Console.WriteLine($"GenerateLetterString: {Utils.Randoms.GenerateLetterString(10)}");
            // Console.WriteLine($"GenerateNumberString: {Utils.Randoms.GenerateNumberString(10)}");
            // Console.WriteLine($"GenerateNumber: {Utils.Randoms.GenerateNumber(10)}");


            // // 加密
            // string key = "12345678", value = "有一个人";

            // Console.WriteLine($"HashMd5: {Utils.Crypt.HashMd5(value)}");

            // Console.WriteLine($"HashSha1: {Utils.Crypt.HashSha1(value)}");
            // Console.WriteLine($"HashSha256: {Utils.Crypt.HashSha256(value)}");
            // Console.WriteLine($"HashSha384: {Utils.Crypt.HashSha384(value)}");
            // Console.WriteLine($"HashSha512: {Utils.Crypt.HashSha512(value)}");

            // Console.WriteLine($"HashHmacSha1: {Utils.Crypt.HashHmacSha1(key, value)}");
            // Console.WriteLine($"HashHmacSha256: {Utils.Crypt.HashHmacSha256(key, value)}");
            // Console.WriteLine($"HashHmacSha384: {Utils.Crypt.HashHmacSha384(key, value)}");
            // Console.WriteLine($"HashHmacSha512: {Utils.Crypt.HashHmacSha512(key, value)}");
            // Console.WriteLine($"HashHmacMd5: {Utils.Crypt.HashHmacMd5(key, value)}");

            // var data = Utils.Crypt.DesEncrypt(key, value);
            // Console.WriteLine($"DesEncrypt: {data}");
            // Console.WriteLine($"DesDecryptor: {Utils.Crypt.DesDecrypt(key, data)}");


            // key = "1234567812345678";
            // data = Utils.Crypt.AesEncrypt(key, "cc0af0a73f56a604545b47e34f56efeb966e6a76");
            // Console.WriteLine($"DesEncrypt: {data}");
            // Console.WriteLine($"DesDecryptor: {Utils.Crypt.AesDecrypt(key, data)}");

            // data = Utils.Crypt.Base64Encrypt(key);
            // Console.WriteLine($"DesEncrypt: {data}");
            // Console.WriteLine($"DesDecryptor: {Utils.Crypt.Base64Decrypt(data)}");

            // var data = "https://open.weixin.qq.com/cgi-bin/showdocument?action=dir_list";
            // Console.WriteLine($"data: {data}");

            // data = Utils.Encode.UrlEncode(data);
            // Console.WriteLine($"UrlEncode: {data}");
            // data = Utils.Encode.UrlDecode(data);
            // Console.WriteLine($"DesEncrypt: {data}");

            // data=Utils.Encode.HtmlEncode(data);
            // Console.WriteLine($"HtmlEncode: {data}");
            // data = Utils.Encode.HtmlDecode(data);
            // Console.WriteLine($"HtmlDecode: {data}");


            // data=Utils.Encode.Base64Encode(data);
            // Console.WriteLine($"Base64Encode: {data}");
            // data = Utils.Encode.Base64Decode(data);
            // Console.WriteLine($"Base64Decode: {data}");


            // var obj = new TestModel()
            // {
            //     Name = "test"
            // };
            // var data = Utils.Serialize.JsonSerializeObject(obj);
            // Console.WriteLine($"JsonSerializeObject: {data}");
            // obj = Utils.Serialize.JsonDeserializeObject<TestModel>(data);
            // Console.WriteLine($"JsonDeserializeObject: {obj.Name}");

            // Console.WriteLine($"JsonDeserializeXmlNode: {Utils.Serialize.JsonDeserializeXmlNode(data)}");


            // data = Utils.Serialize.XmlSerializeObject(obj);
            // Console.WriteLine($"XmlSerializeObject: {data}");

            // Console.WriteLine($"JsonSerializeXmlNode: {Utils.Serialize.JsonSerializeXmlNode(data)}");

            // var newObj = Utils.Serialize.XmlDeserializeObject<TestModel>(data);
            // Console.WriteLine($"XmlDeserializeObject: {newObj.Name}");

            // var dt = DateTime.Now;
            // Console.WriteLine($"dt: {dt}");
            // var data = Utils.TimeHelper.ToUnixTimeStamp(dt);
            // Console.WriteLine($"ToUnixTimeStamp: {data}");
            // dt = Utils.TimeHelper.ToLocalTimeTime(data);
            // Console.WriteLine($"ToLocalTimeTime: {dt}");
            // dt = DateTime.Parse("2019-07-01");
            // Console.WriteLine($"IsToday: {Utils.TimeHelper.IsToday(dt)}");
            // Console.WriteLine($"GetMonday: {Utils.TimeHelper.GetMonday(dt)}");
            // Console.WriteLine($"GetMonthFirstDay: {Utils.TimeHelper.GetMonthFirstDay(dt)}");
            // Console.WriteLine($"GetQuarterFirstDay: {Utils.TimeHelper.GetQuarterFirstDay(dt)}");
            // Console.WriteLine($"GetYearsFirstDay: {Utils.TimeHelper.GetYearsFirstDay(dt)}");


            var path = "/Users/tanqingliang/Project/Utils/src/Demo";
            var data = Utils.FileHelper.GetDirectoryFiles(path);
            Console.WriteLine($"GetDirectoryFiles：{data.JsonSerializeObject()}");
            data = Utils.FileHelper.GetDirectoryFiles(path, true);
            Console.WriteLine($"GetDirectoryFiles：{data.JsonSerializeObject()}");

        }
    }

    public class TestModel
    {
        public string Name { set; get; }
    }
}
