namespace Utils
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using QRCoder;

    /// <summary>
    /// 图片
    /// </summary>
    public class ImageHelper
    {

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="filePath">保存地址</param>
        /// <param name="code">内容</param>
        /// <param name="width">图片宽</param>
        /// <param name="height">图片高</param>
        public static void GenerateVerifyCode(string filePath, string code, int width = 100, int height = 40)
        {
            byte[] data = GenerateVerifyCode(code, width, height);

            using (MemoryStream ms = new MemoryStream(data))
            {
                var img = Image.FromStream(ms);
                img.Save(filePath);
            }
        }
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="code">内容</param>
        /// <param name="width">图片宽</param>
        /// <param name="height">图片高</param>
        /// <returns>字节</returns>
        public static byte[] GenerateVerifyCode(string code, int width = 100, int height = 40)
        {
            var fonts = new Font[] {
                new Font(new FontFamily("Times New Roman"), 18 + RandomHelper.GenerateNumber(4),System.Drawing.FontStyle.Bold),
                new Font(new FontFamily("Georgia"), 18 + RandomHelper.GenerateNumber(4),System.Drawing.FontStyle.Bold),
                new Font(new FontFamily("Arial"), 18 + RandomHelper.GenerateNumber(4),System.Drawing.FontStyle.Bold),
                new Font(new FontFamily("Comic Sans MS"), 18 + RandomHelper.GenerateNumber(4),System.Drawing.FontStyle.Bold)
            };

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            Graphics g = Graphics.FromImage(bitmap);
            Rectangle rect = new Rectangle(0, 0, width, height);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(Color.White);

            int fixedNumber = 10;
            // int fixedNumber = textcolor == 2 ? 60 : 0;
            //创建干扰线
            SolidBrush drawBrush = new SolidBrush(Color.FromArgb(RandomHelper.GenerateNumber(100), RandomHelper.GenerateNumber(100), RandomHelper.GenerateNumber(100)));
            for (int x = 0; x < 2; x++)
            {
                Pen linePen = new Pen(Color.FromArgb(RandomHelper.GenerateNumber(150) + fixedNumber, RandomHelper.GenerateNumber(150) + fixedNumber, RandomHelper.GenerateNumber(150) + fixedNumber), 1);
                g.DrawLine(linePen, new PointF(0.0F + RandomHelper.GenerateNumber(20), 0.0F + RandomHelper.GenerateNumber(height)), new PointF(0.0F + RandomHelper.GenerateNumber(width), 0.0F + RandomHelper.GenerateNumber(height)));
            }


            Matrix m = new Matrix();
            for (int x = 0; x < code.Length; x++)
            {
                m.Reset();
                m.RotateAt(RandomHelper.GenerateNumber(30) - 15, new PointF(Convert.ToInt64(width * (0.10 * x)), Convert.ToInt64(height * 0.5)));
                g.Transform = m;
                drawBrush.Color = Color.FromArgb(RandomHelper.GenerateNumber(150) + fixedNumber + 20, RandomHelper.GenerateNumber(150) + fixedNumber + 20, RandomHelper.GenerateNumber(150) + fixedNumber + 20);
                PointF drawPoint = new PointF(0.0F + RandomHelper.GenerateNumber(4) + x * 20, 3.0F + RandomHelper.GenerateNumber(3));
                g.DrawString(RandomHelper.GenerateNumber(1) == 1 ? code[x].ToString() : code[x].ToString().ToUpper(), fonts[RandomHelper.GenerateNumber(fonts.Length - 1)], drawBrush, drawPoint);
                g.ResetTransform();
            }


            //扭曲验证码
            double distort = RandomHelper.GenerateNumber(5, 10) * (RandomHelper.GenerateNumber(10) == 1 ? 1 : -1);

            using (Bitmap copy = (Bitmap)bitmap.Clone())
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int newX = (int)(x + (distort * Math.Sin(Math.PI * y / 84.5)));
                        int newY = (int)(y + (distort * Math.Cos(Math.PI * x / 54.5)));
                        if (newX < 0 || newX >= width)
                            newX = 0;
                        if (newY < 0 || newY >= height)
                            newY = 0;
                        bitmap.SetPixel(x, y, copy.GetPixel(newX, newY));
                    }
                }
            }

            drawBrush.Dispose();
            g.Dispose();

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();

        }


        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="filePath">保存地址</param>
        /// <param name="code">内容</param>
        /// <param name="level">容错级别</param>
        /// <param name="forceUtf8">输入内容编码UTF8</param>
        /// <param name="utf8BOM">输出内容编码UTF8</param>
        /// <param name="eciMode">压缩模式</param>
        public static void GenerateQRCode(string filePath, string code, QRCodeGenerator.ECCLevel level = QRCodeGenerator.ECCLevel.M, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default)
        {
            // 生成二维码
            QRCode qrCode = GenerateQRCode(code, level, forceUtf8, utf8BOM, eciMode);

            // 画图
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            // 保存
            qrCodeImage.Save(filePath);
        }
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="code">内容</param>
        /// <param name="level">容错级别</param>
        /// <param name="forceUtf8">输入内容编码UTF8</param>
        /// <param name="utf8BOM">输出内容编码UTF8</param>
        /// <param name="eciMode">压缩模式</param>
        /// <returns>二维码对象</returns>
        public static QRCode GenerateQRCode(string code, QRCodeGenerator.ECCLevel level = QRCodeGenerator.ECCLevel.M, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default)
        {
            // 生成二维码
            var qrCodeData = new QRCodeGenerator().CreateQrCode(code, level, forceUtf8, utf8BOM, eciMode);

            return new QRCode(qrCodeData);
        }



    }
}