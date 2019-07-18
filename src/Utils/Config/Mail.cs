namespace Utils.Config
{
    /// <summary>
    /// 邮箱发送配置
    /// </summary>
    public class Mail
    {

        /// <summary>
        /// SMTP 服务地址
        /// </summary>
        /// <value></value>
        public string SmtpHost { set; get; }
        /// <summary>
        /// SMTP 服务端口
        /// </summary>
        /// <value></value>
        public int SmtpPort { set; get; }
        /// <summary>
        /// SMTP 是否SSL加密
        /// </summary>
        /// <value></value>
        public bool SmtpSsl { set; get; }
        /// <summary>
        /// 用户名
        /// </summary>
        /// <value></value>
        public string UserName { set; get; }
        /// <summary>
        /// 密码
        /// </summary>
        /// <value></value>
        public string Password { set; get; }
        /// <summary>
        /// 发送人
        /// </summary>
        /// <value></value>
        public string FromName { set; get; }
        /// <summary>
        /// 发送人邮箱地址
        /// </summary>
        /// <value></value>
        public string FromAddress { set; get; }
    }
}