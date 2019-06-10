namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MailKit.Net.Smtp;
    using MailKit;
    using MimeKit;

    /// <summary>
    /// 邮箱
    /// </summary>
    public class MailHelper
    {


        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="cof">发送邮箱配置</param>
        /// <param name="to">收件人</param>
        /// <param name="subject">发送主题</param>
        /// <param name="body">发送内容</param>
        public static void Send(MailConfig cof, string[] to, string subject, string body)
        {
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;

            Send(cof, to, subject, bodyBuilder);
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="cof">发送邮箱配置</param>
        /// <param name="to">收件人</param>
        /// <param name="subject">发送主题</param>
        /// <param name="body">发送内容</param>
        public static void Send(MailConfig cof, string[] to, string subject, BodyBuilder body)
        {
            InternetAddressList toList = new InternetAddressList();
            foreach (var item in to)
            {
                toList.Add(new MailboxAddress(item));
            }

            Send(cof, toList, null, null, subject, body);
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="cof">发送邮箱配置</param>
        /// <param name="to">收件人</param>
        /// <param name="cc">抄送人</param>
        /// <param name="cc">密抄人</param>
        /// <param name="subject">发送主题</param>
        /// <param name="body">发送内容</param>
        public static void Send(MailConfig cof, InternetAddressList to, InternetAddressList cc, InternetAddressList bcc, string subject, BodyBuilder body)
        {
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(cof.SmtpHost, cof.SmtpPort, cof.SmtpSsl);

                client.Authenticate(cof.FromAddress, cof.Password);

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(cof.FromName, cof.FromAddress));

                message.To.AddRange(to);
                if (cc != null)
                {
                    message.Cc.AddRange(cc);
                }
                if (bcc != null)
                {
                    message.Bcc.AddRange(bcc);
                }

                message.Subject = subject;
                message.Body = body.ToMessageBody();

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }

    /// <summary>
    /// 发送邮箱配置
    /// </summary>
    public class MailConfig
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