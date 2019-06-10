namespace Utils
{
    using System;

    /// <summary>
    /// (正则验证) 扩展属性
    /// </summary>
    public static partial class RegexExtensions
    {



        /// <summary>
        /// 验证字符串是否匹配正则表达式描述的规则
        /// </summary>
        /// <param name="inputStr">待验证的字符串</param>
        /// <param name="patternStr">正则表达式字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsMatch(this string inputStr, string patternStr)
        {
            return RegexHelper.IsMatch(inputStr, patternStr, false, false);
        }




        /// <summary>
        /// 验证数字(double类型)
        /// [可以包含负号和小数点]
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsNumber(this string input)
        {
            return RegexHelper.IsNumber(input);
        }

        /// <summary>
        /// 验证整数
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsInteger(this string input)
        {
            return RegexHelper.IsInteger(input);
        }

        /// <summary>
        /// 验证非负整数
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsIntegerNotNagtive(this string input)
        {
            return RegexHelper.IsIntegerNotNagtive(input);

        }

        /// <summary>
        /// 验证正整数
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsIntegerPositive(this string input)
        {
            return RegexHelper.IsIntegerPositive(input);
        }

        /// <summary>
        /// 验证小数
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsDecimal(this string input)
        {
            return RegexHelper.IsDecimal(input);
        }

        /// <summary>
        /// 验证只包含英文字母
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsEnglishCharacter(this string input)
        {
            return RegexHelper.IsEnglishCharacter(input);
        }

        /// <summary>
        /// 验证只包含数字和英文字母
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsIntegerAndEnglishCharacter(this string input)
        {
            return RegexHelper.IsIntegerAndEnglishCharacter(input);
        }

        /// <summary>
        /// 验证只包含汉字
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsChineseCharacter(this string input)
        {
            return RegexHelper.IsChineseCharacter(input);
        }


        /// <summary>
        /// 验证日期
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsDateTime(this string input)
        {
            return RegexHelper.IsDateTime(input);
        }

        /// <summary>
        /// 验证固定电话号码
        /// [3位或4位区号；区号可以用小括号括起来；区号可以省略；区号与本地号间可以用减号或空格隔开；可以有3位数的分机号，分机号前要加减号]
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsTelePhoneNumber(this string input)
        {
            return RegexHelper.IsTelePhoneNumber(input);
        }

        /// <summary>
        /// 验证手机号码
        /// [可匹配"(+86)013325656352"，括号可以省略，+号可以省略，(+86)可以省略，11位手机号前的0可以省略；11位手机号第二位数可以是3、4、5、6、7、8、9中的任意一个]
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsMobilePhoneNumber(this string input)
        {
            return RegexHelper.IsMobilePhoneNumber(input);
        }

        /// <summary>
        /// 验证电话号码（可以是固定电话号码或手机号码）
        /// [固定电话：[3位或4位区号；区号可以用小括号括起来；区号可以省略；区号与本地号间可以用减号或空格隔开；可以有3位数的分机号，分机号前要加减号]]
        /// [手机号码：[可匹配"(+86)013325656352"，括号可以省略，+号可以省略，(+86)可以省略，手机号前的0可以省略；手机号第二位数可以是3、4、5、6、7、8、9中的任意一个]]
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsPhoneNumber(this string input)
        {
            return RegexHelper.IsPhoneNumber(input);
        }

        /// <summary>
        /// 验证邮政编码
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsZipCode(this string input)
        {
            return RegexHelper.IsZipCode(input);
        }

        /// <summary>
        /// 验证电子邮箱
        /// [@字符前可以包含字母、数字、下划线和点号；@字符后可以包含字母、数字、下划线和点号；@字符后至少包含一个点号且点号不能是最后一个字符；最后一个点号后只能是字母或数字]
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsEmail(this string input)
        {
            return RegexHelper.IsEmail(input);
        }

        /// <summary>
        /// 验证网址（可以匹配IPv4地址但没对IPv4地址进行格式验证；IPv6暂时没做匹配）
        /// [允许省略"://"；可以添加端口号；允许层级；允许传参；域名中至少一个点号且此点号前要有内容]
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsURL(this string input)
        {
            return RegexHelper.IsURL(input);
        }




        /// <summary>
        /// 验证一代身份证号（15位数）
        /// [长度为15位的数字；匹配对应省份地址；生日能正确匹配]
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsIDCard15(this string input)
        {
            return RegexHelper.IsIDCard15(input);
        }

        /// <summary>
        /// 验证二代身份证号（18位数，GB11643-1999标准）
        /// [长度为18位；前17位为数字，最后一位(校验码)可以为大小写x；匹配对应省份地址；生日能正确匹配；校验码能正确匹配]
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsIDCard18(this string input)
        {
            return RegexHelper.IsIDCard18(input);
        }

        /// <summary>
        /// 验证身份证号（不区分一二代身份证号）
        /// </summary>
        /// <param name="input">待验证的字符串</param>
        /// <returns>是否匹配</returns>
        public static bool IsIDCard(this string input)
        {
            return RegexHelper.IsIDCard(input);
        }




    }
}