namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Security.Cryptography;

    /// <summary>
    /// 加密&解密
    /// </summary>
    public class Crypt
    {

        /// <summary>
        /// MD5加密 
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashMd5(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            using (var hash = MD5.Create())
            {
                byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BytesToString(data);
            }
        }

        /// <summary>
        /// SHA1 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha1(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            using (var hash = SHA1.Create())
            {
                byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BytesToString(data);
            }
        }

        /// <summary>
        /// SHA256 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha256(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            using (var hash = SHA256.Create())
            {
                byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BytesToString(data);
            }
        }

        /// <summary>
        /// SHA384 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha384(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            using (var hash = SHA384.Create())
            {
                byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BytesToString(data);
            }
        }

        /// <summary>
        /// SHA512 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha512(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            using (var hash = SHA512.Create())
            {
                byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BytesToString(data);
            }
        }



        /// <summary>
        /// HMACSHA1 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashHmacSha1(string key, string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            using (var hash = new HMACSHA1(Encoding.UTF8.GetBytes(key)))
            {
                byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BytesToString(data);
            }
        }


        /// <summary>
        /// HMACSHA256 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashHmacSha256(string key, string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            using (var hash = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BytesToString(data);
            }
        }

        /// <summary>
        /// HMACSHA384 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashHmacSha384(string key, string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            using (var hash = new HMACSHA384(Encoding.UTF8.GetBytes(key)))
            {
                byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BytesToString(data);
            }
        }

        /// <summary>
        /// HMACSHA512 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashHmacSha512(string key, string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            using (var hash = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
            {
                byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BytesToString(data);
            }
        }

        /// <summary>
        /// HMACMD5 加密
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashHmacMd5(string key, string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            using (var hash = new HMACMD5(Encoding.UTF8.GetBytes(key)))
            {
                byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BytesToString(data);
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
            var data = DesEncrypt(
                Encoding.UTF8.GetBytes(key),
                Encoding.UTF8.GetBytes(iv),
                Encoding.UTF8.GetBytes(input)
            );

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
                // rijAlg.Mode = CipherMode.CBC;
                // rijAlg.Padding = PaddingMode.PKCS7;

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
                Encoding.UTF8.GetBytes(key),
                Encoding.UTF8.GetBytes(iv),
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
                // rijAlg.Mode = CipherMode.CBC;
                // rijAlg.Padding = PaddingMode.PKCS7;

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
                Encoding.UTF8.GetBytes(key),
                Encoding.UTF8.GetBytes(iv),
                Encoding.UTF8.GetBytes(input)
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
                // rijAlg.Mode = CipherMode.CBC;
                // rijAlg.Padding = PaddingMode.PKCS7;

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
                Encoding.UTF8.GetBytes(key),
                Encoding.UTF8.GetBytes(iv),
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
                // rijAlg.Mode = CipherMode.CBC;
                // rijAlg.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform decryptor = rijAlg.CreateDecryptor())
                {
                    return Decrypt(decryptor, input);
                }

            }
        }


        /// <summary>
        /// Base64 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string Base64Encrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// Base64 解密
        /// </summary>
        /// <param name="input">解密内容</param>
        /// <returns></returns>
        public static string Base64Decrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            byte[] bytes = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(bytes);
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

        /// <summary>
        /// 字节转字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static string BytesToString(byte[] data)
        {
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

    }
}