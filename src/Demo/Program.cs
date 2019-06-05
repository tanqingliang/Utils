using System;
using System.Security.Cryptography;


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


            // 加密
            string key = "12345678", value = "有一个人";

            Console.WriteLine($"HashMd5: {Utils.Crypt.HashMd5(value)}");

            Console.WriteLine($"HashSha1: {Utils.Crypt.HashSha1(value)}");
            Console.WriteLine($"HashSha256: {Utils.Crypt.HashSha256(value)}");
            Console.WriteLine($"HashSha384: {Utils.Crypt.HashSha384(value)}");
            Console.WriteLine($"HashSha512: {Utils.Crypt.HashSha512(value)}");

            Console.WriteLine($"HashHmacSha1: {Utils.Crypt.HashHmacSha1(key, value)}");
            Console.WriteLine($"HashHmacSha256: {Utils.Crypt.HashHmacSha256(key, value)}");
            Console.WriteLine($"HashHmacSha384: {Utils.Crypt.HashHmacSha384(key, value)}");
            Console.WriteLine($"HashHmacSha512: {Utils.Crypt.HashHmacSha512(key, value)}");
            Console.WriteLine($"HashHmacMd5: {Utils.Crypt.HashHmacMd5(key, value)}");

            var data = Utils.Crypt.DesEncrypt(key, value);
            Console.WriteLine($"DesEncrypt: {data}");
            Console.WriteLine($"DesDecryptor: {Utils.Crypt.DesDecrypt(key, data)}");


            key = "1234567812345678";
            data = Utils.Crypt.AesEncrypt(key, "cc0af0a73f56a604545b47e34f56efeb966e6a76");
            Console.WriteLine($"DesEncrypt: {data}");
            Console.WriteLine($"DesDecryptor: {Utils.Crypt.AesDecrypt(key, data)}");

            data = Utils.Crypt.Base64Encrypt(key);
            Console.WriteLine($"DesEncrypt: {data}");
            Console.WriteLine($"DesDecryptor: {Utils.Crypt.Base64Decrypt(data)}");




        }
    }
}
