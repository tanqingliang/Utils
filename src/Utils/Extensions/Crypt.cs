namespace Utils
{
    /// <summary>
    /// （加密) 扩展属性
    /// </summary>
    public static partial class Extensions
    {


        /// <summary>
        /// MD5加密 
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashMd5(this string input)
        {
            return Crypt.HashMd5(input);
        }

        /// <summary>
        /// SHA1 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha1(this string input)
        {
            return Crypt.HashSha1(input);
        }

        /// <summary>
        /// SHA256 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha256(this string input)
        {
            return Crypt.HashSha256(input);
        }

        /// <summary>
        /// SHA384 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha384(this string input)
        {
            return Crypt.HashSha384(input);
        }

        /// <summary>
        /// SHA512 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha512(this string input)
        {
            return Crypt.HashSha512(input);
        }



        /// <summary>
        /// HMACSHA1 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string HashHmacSha1(this string input, string key)
        {
            return Crypt.HashHmacSha1(input, key);
        }


        /// <summary>
        /// HMACSHA256 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string HashHmacSha256(this string input, string key)
        {
            return Crypt.HashHmacSha256(input, key);
        }

        /// <summary>
        /// HMACSHA384 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string HashHmacSha384(this string input, string key)
        {
            return Crypt.HashHmacSha384(input, key);
        }


        /// <summary>
        /// HMACSHA512 加密
        /// </summary>        
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string HashHmacSha512(this string input, string key)
        {
            return Crypt.HashHmacSha512(input, key);
        }



        /// <summary>
        /// HMACMD5 加密
        /// </summary>        
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string HashHmacMd5(this string input, string key)
        {
            return Crypt.HashHmacMd5(input, key);
        }


        /// <summary>
        /// DES 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>        
        /// <returns></returns>
        public static string DesEncrypt(this string input, string key)
        {
            return Crypt.DesEncrypt(input, key);
        }

        /// <summary>
        /// DES 解密
        /// </summary>
        /// <param name="input">解密内容</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string DesDecrypt(this string input, string key)
        {
            return Crypt.DesDecrypt(input, key);
        }



        /// <summary>
        /// AES 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>        
        /// <returns></returns>
        public static string AesEncrypt(this string input, string key)
        {
            return Crypt.AesEncrypt(input, key);
        }


        /// <summary>
        /// AES 解密
        /// </summary>
        /// <param name="input">解密内容</param>
        /// <param name="key">秘钥</param>    
        /// <returns></returns>
        public static string AesDecrypt(this string input, string key)
        {
            return Crypt.AesDecrypt(input, key);
        }


        /// <summary>
        /// Base64 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string Base64Encrypt(this string input)
        {
            return Crypt.Base64Encrypt(input);
        }
        /// <summary>
        /// Base64 解密
        /// </summary>
        /// <param name="input">解密内容</param>
        /// <returns></returns>
        public static string Base64Decrypt(this string input)
        {
            return Crypt.Base64Decrypt(input);
        }

    }
}