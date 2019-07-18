namespace Utils.Extensions
{

    /// <summary>
    /// （加密) 扩展方法
    /// </summary>
    public static class CryptExtensions
    {

        /// <summary>
        /// MD5加密 
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashMd5(this string input)
        {
            return CryptHelper.HashMd5(input);
        }

        /// <summary>
        /// SHA1 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha1(this string input)
        {
            return CryptHelper.HashSha1(input);
        }

        /// <summary>
        /// SHA256 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha256(this string input)
        {
            return CryptHelper.HashSha256(input);
        }

        /// <summary>
        /// SHA384 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha384(this string input)
        {
            return CryptHelper.HashSha384(input);
        }

        /// <summary>
        /// SHA512 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <returns></returns>
        public static string HashSha512(this string input)
        {
            return CryptHelper.HashSha512(input);
        }



        /// <summary>
        /// HMACSHA1 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string HashHmacSha1(this string input, string key)
        {
            return CryptHelper.HashHmacSha1(key, input);
        }


        /// <summary>
        /// HMACSHA256 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string HashHmacSha256(this string input, string key)
        {
            return CryptHelper.HashHmacSha256(key, input);
        }

        /// <summary>
        /// HMACSHA384 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string HashHmacSha384(this string input, string key)
        {
            return CryptHelper.HashHmacSha384(key, input);
        }


        /// <summary>
        /// HMACSHA512 加密
        /// </summary>        
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string HashHmacSha512(this string input, string key)
        {
            return CryptHelper.HashHmacSha512(key, input);
        }



        /// <summary>
        /// HMACMD5 加密
        /// </summary>        
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string HashHmacMd5(this string input, string key)
        {
            return CryptHelper.HashHmacMd5(key, input);
        }


        /// <summary>
        /// DES 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>        
        /// <returns></returns>
        public static string DesEncrypt(this string input, string key)
        {
            return CryptHelper.DesEncrypt(key, input);
        }

        /// <summary>
        /// DES 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>      
        /// <param name="iv">向量</param>      
        /// <returns></returns>
        public static string DesEncrypt(this string input, string key, string iv)
        {
            return CryptHelper.DesEncrypt(key, iv, input);
        }

        /// <summary>
        /// DES 解密
        /// </summary>
        /// <param name="input">解密内容</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string DesDecrypt(this string input, string key)
        {
            return CryptHelper.DesDecrypt(key, input);
        }


        /// <summary>
        /// DES 解密
        /// </summary>
        /// <param name="input">解密内容</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>    
        /// <returns></returns>
        public static string DesDecrypt(this string input, string key, string iv)
        {
            return CryptHelper.DesDecrypt(key, iv, input);
        }


        /// <summary>
        /// AES 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>        
        /// <returns></returns>
        public static string AesEncrypt(this string input, string key)
        {
            return CryptHelper.AesEncrypt(key, input);
        }


        /// <summary>
        /// AES 加密
        /// </summary>
        /// <param name="input">加密内容</param>
        /// <param name="key">秘钥</param>        
        /// <param name="iv">向量</param>    
        /// <returns></returns>
        public static string AesEncrypt(this string input, string key, string iv)
        {
            return CryptHelper.AesEncrypt(key, iv, input);
        }


        /// <summary>
        /// AES 解密
        /// </summary>
        /// <param name="input">解密内容</param>
        /// <param name="key">秘钥</param>    
        /// <returns></returns>
        public static string AesDecrypt(this string input, string key)
        {
            return CryptHelper.AesDecrypt(key, input);
        }

        /// <summary>
        /// AES 解密
        /// </summary>
        /// <param name="input">解密内容</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>    
        /// <returns></returns>
        public static string AesDecrypt(this string input, string key, string iv)
        {
            return CryptHelper.AesDecrypt(key, iv, input);
        }


    }
}