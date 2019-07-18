namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography;
    using Extensions;

    /// <summary>
    /// 加密&解密
    /// </summary>
    public class CryptHelper
    {

        /// <summary>
        /// MD5加密 
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashMd5(string input)
        {
            return Hash(MD5.Create(), input);
        }

        /// <summary>
        /// SHA1 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha1(string input)
        {
            return Hash(SHA1.Create(), input);
        }

        /// <summary>
        /// SHA256 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha256(string input)
        {
            return Hash(SHA256.Create(), input);
        }

        /// <summary>
        /// SHA384 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha384(string input)
        {
            return Hash(SHA384.Create(), input);
        }

        /// <summary>
        /// SHA512 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha512(string input)
        {
            return Hash(SHA512.Create(), input);
        }


        /// <summary>
        /// HMACSHA1 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashHmacSha1(string key, string input)
        {
            return Hash(new HMACSHA1(key.BytesEncode()), input);
        }


        /// <summary>
        /// HMACSHA256 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashHmacSha256(string key, string input)
        {
            return Hash(new HMACSHA256(key.BytesEncode()), input);
        }

        /// <summary>
        /// HMACSHA384 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashHmacSha384(string key, string input)
        {
            return Hash(new HMACSHA384(key.BytesEncode()), input);
        }

        /// <summary>
        /// HMACSHA512 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashHmacSha512(string key, string input)
        {
            return Hash(new HMACSHA512(key.BytesEncode()), input);
        }

        /// <summary>
        /// HMACMD5 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashHmacMd5(string key, string input)
        {
            return Hash(new HMACMD5(key.BytesEncode()), input);
        }


        /// <summary>
        /// hash 加密
        /// </summary>
        /// <param name="hash">hash 加密对象</param>
        /// <param name="input">加密内容</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        static string Hash<T>(T hash, string input) where T : HashAlgorithm
        {
            try
            {
                // 判断是否为空
                if (input.IsNullOrEmpty())
                    return string.Empty;

                // hash 加密
                byte[] data = hash.ComputeHash(input.BytesEncode());


                StringBuilder sBuilder = new StringBuilder();

                //遍历散列数据的每个字节
                //并将每个格式化为十六进制字符串。
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
            finally
            {
                hash.Clear();
                hash.Dispose();
            }
        }


        /// <summary>
        /// DES 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string DesEncrypt(string key, string input)
        {
            return DesEncrypt(key, key, input);
        }
        /// <summary>
        /// DES 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string DesEncrypt(string key, string iv, string input)
        {
            var data = DesEncrypt(key.BytesEncode(), iv.BytesEncode(), input.BytesEncode());

            return Convert.ToBase64String(data);
        }
        /// <summary>
        /// DES 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static byte[] DesEncrypt(byte[] key, byte[] iv, byte[] input)
        {
            using (DES rijAlg = DES.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                using (ICryptoTransform encryptor = rijAlg.CreateEncryptor())
                {
                    return Encrypt(encryptor, input);
                }
            }
        }

        /// <summary>
        /// DES 解密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">解密内容</param>
        /// <returns></returns>
        public static string DesDecrypt(string key, string input)
        {
            return DesDecrypt(key, key, input);
        }
        /// <summary>
        /// DES 解密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="input">解密内容</param>
        /// <returns></returns>
        public static string DesDecrypt(string key, string iv, string input)
        {
            var data = DesDecrypt(
                key.BytesEncode(),
                iv.BytesEncode(),
                Convert.FromBase64String(input)
            );

            return Encoding.UTF8.GetString(data);
        }
        /// <summary>
        /// DES 解密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="input">解密内容</param>
        /// <returns></returns>
        public static byte[] DesDecrypt(byte[] key, byte[] iv, byte[] input)
        {
            using (DES rijAlg = DES.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;


                using (ICryptoTransform decryptor = rijAlg.CreateDecryptor())
                {
                    return Decrypt(decryptor, input);
                }
            }
        }




        /// <summary>
        /// AES 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string AesEncrypt(string key, string input)
        {
            return AesEncrypt(key, key, input);
        }
        /// <summary>
        /// AES 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string AesEncrypt(string key, string iv, string input)
        {
            var data = AesEncrypt(
                key.BytesEncode(),
                iv.BytesEncode(),
                input.BytesEncode()
            );

            return Convert.ToBase64String(data);
        }
        /// <summary>
        /// AES 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static byte[] AesEncrypt(byte[] key, byte[] iv, byte[] input)
        {
            using (Aes rijAlg = Aes.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;


                using (ICryptoTransform encryptor = rijAlg.CreateEncryptor())
                {
                    return Encrypt(encryptor, input);
                }
            }
        }


        /// <summary>
        /// AES 解密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">解密内容</param>
        /// <returns></returns>
        public static string AesDecrypt(string key, string input)
        {
            return AesDecrypt(key, key, input);
        }
        /// <summary>
        /// AES 解密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="input">解密内容</param>
        /// <returns></returns>
        public static string AesDecrypt(string key, string iv, string input)
        {

            var data = AesDecrypt(
                key.BytesEncode(),
                iv.BytesEncode(),
                Convert.FromBase64String(input)
            );

            return Encoding.UTF8.GetString(data);
        }
        /// <summary>
        /// AES 解密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="input">解密内容</param>
        /// <returns></returns>
        public static byte[] AesDecrypt(byte[] key, byte[] iv, byte[] input)
        {
            using (Aes rijAlg = Aes.Create())
            {

                rijAlg.Key = key;
                rijAlg.IV = iv;


                using (ICryptoTransform decryptor = rijAlg.CreateDecryptor())
                {
                    return Decrypt(decryptor, input);
                }

            }
        }



        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptor"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        static byte[] Encrypt(ICryptoTransform encryptor, byte[] input)
        {
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(input, 0, input.Length);
                    csEncrypt.Close();
                    msEncrypt.Flush();

                    return msEncrypt.ToArray();
                }
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptor"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        static byte[] Decrypt(ICryptoTransform decryptor, byte[] input)
        {
            using (MemoryStream msDecrypt = new MemoryStream(input))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (MemoryStream tempMemory = new MemoryStream())
                    {
                        byte[] Buffer = new byte[1024];
                        int readBytes = 0;
                        while ((readBytes = csDecrypt.Read(Buffer, 0, Buffer.Length)) > 0)
                        {
                            tempMemory.Write(Buffer, 0, readBytes);
                        }
                        tempMemory.Close();
                        csDecrypt.Close();
                        msDecrypt.Flush();

                        return tempMemory.ToArray();
                    }
                }
            }
        }



    }
}